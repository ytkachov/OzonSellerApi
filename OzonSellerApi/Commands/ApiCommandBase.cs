using Newtonsoft.Json;
using NLog;
using OzonSellerApi.Interfaces;
using OzonSellerApi.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OzonSellerApi.Commands
{
	public class ApiCommandBase<TOut>
	{
		private ApiCommandAttributeBase _api_command_attribute;
		private readonly static ILogger logger = LogManager.GetCurrentClassLogger();
		public IApiConnection Connection { get; set; }
		protected static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None, NullValueHandling = NullValueHandling.Ignore };
		private ApiCommandAttributeBase ApiCommand
		{
			get
			{
				if (_api_command_attribute == null)
					_api_command_attribute = GetType().GetCustomAttribute<ApiCommandAttributeBase>(true);

				return _api_command_attribute;
			}
		}

		public HttpMethod Method { get; set; }
		public ApiMethodParamsBase MethodParameters { get; set; }
		public string Url
		{
			get
			{
				if (ApiCommand == null)
					return string.Empty;

				return "/" + ApiCommand.SchemaVersion.ToString() + ApiCommand.Url;
			}
		}

		public ApiCommandBase()
		{
			Method = ApiCommand.Method;  //Url?
		}

		public ApiCommandBase(ApiConnection connection) : this()
		{
			Connection = connection;
		}

		public string JsonResponse { get; protected set; }
		public ApiSimpleResponseMessage<TOut> Response { get; protected set; }

    	protected virtual TOut Deserialize(string jsonData, HttpResponseMessage response)
		{
			var responseBase = JsonConvert.DeserializeObject<ApiResponseMessageBase>(jsonData, SerializerSettings);

			// response with errors
			if (responseBase.Code != null && responseBase.Code.Length > 0)
			{
				throw new ApiException(responseBase.Message + ", " + (responseBase.Details == null ? "" : string.Join(", ", responseBase.Details.Select(item => "'" + item + "'"))),
					response.Content,
					responseBase.Error);
			}

			Response = JsonConvert.DeserializeObject<ApiSimpleResponseMessage<TOut>>(jsonData, SerializerSettings);
			return Response.Result;
		}

        protected virtual string PrepareRequest(ApiMethodParamsBase data = null)
        {
            if (Connection == null)
                throw new ApiException("Connection object is not defined");

            if (data != null)
                MethodParameters = data;

            logger.Info($"{this.GetType().Name} = {Url}, {data?.GetType().Name}");

            return MethodParameters?.ToJson();
        }

        public virtual TOut Execute(ApiMethodParamsBase data = null)
        {
            var request = PrepareRequest(data);
            try
            {
                HttpResponseMessage response = Task.Run(() => Connection.PostRequestAsync(request, Url, Method)).Result;
                // if wrong api URL or server is broken we won't get json result
                if (response.Content.Headers.ContentType.MediaType == "text/plain")
                    throw new ApiException("Unexpected response: " + $"{(int)response.StatusCode}. {response.ReasonPhrase}" + ", url: " + Url, response.Content);

                JsonResponse = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
                return ProcessResponse(response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error requesting Url {Url}.\r\nRequest: {request}\r\nResponse: {JsonResponse}. {Environment.NewLine} {ex.Message}");
                throw;
            }
        }

        public virtual async Task<TOut> ExecuteAsync(ApiMethodParamsBase data = null)
		{
            var request = PrepareRequest(data);
			try
			{
				HttpResponseMessage response = await Connection.PostRequestAsync(request, Url, Method);
                // if wrong api URL or server is broken we won't get json result
                if (response.Content.Headers.ContentType.MediaType == "text/plain")
                    throw new ApiException("Unexpected response: " + $"{(int)response.StatusCode}. {response.ReasonPhrase}" + ", url: " + Url, response.Content);

                JsonResponse = await response.Content.ReadAsStringAsync();
                return ProcessResponse(response);
			}
			catch (Exception ex)
			{
				logger.Error(ex, $"Error requesting Url {Url}.\r\nRequest: {request}\r\nResponse: {JsonResponse}. {Environment.NewLine} {ex.Message}");
				throw;
			}
		}

        private TOut ProcessResponse(HttpResponseMessage response)
        {
            JsonResponse = JsonResponse.DecodeEncodedNonAsciiCharacters();
            var outResult = Deserialize(JsonResponse, response);

            switch ((int)response.StatusCode)
            {
                // documented response status codes
                case (int)HttpStatusCode.NotFound:
                case (int)HttpStatusCode.Forbidden:
                case (int)HttpStatusCode.Unauthorized:
                case (int)HttpStatusCode.Conflict:
                case (int)HttpStatusCode.InternalServerError:
                case (int)HttpStatusCode.OK:
                    break;

                default:
                    throw new ApiException("Unexpected http status code", response.Content);
            }

            return outResult;
        }
    }
}
