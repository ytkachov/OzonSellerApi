using OzonSellerApi.ApiCommands;
using OzonSellerApi.Interfaces;
using OzonSellerApi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonSellerApi
{
	public class OzonSellerApiService
	{
		private static readonly Lazy<OzonSellerApiService> lazy = new Lazy<OzonSellerApiService>(() => new OzonSellerApiService());
		public static OzonSellerApiService Instance => lazy.Value;
		public IApiConnection Connection { get; protected set; }

		private OzonSellerApiService()
		{
			Connection = new ApiConnection();
		}

		public void Configure(string baseApiUrl = null, string apiKey = null, string clientId = null)
		{
			Connection.Configure(baseApiUrl, apiKey, clientId);
		}

        public List<Warehouse> GetWarehouseList()
        {
            var cmd = new GetWarehouseListCommand { Connection = Connection };
            var result = cmd.Execute();

            return result;
        }

        public async Task<List<Warehouse>> GetWarehouseListAsync()
        {
            var cmd = new GetWarehouseListCommand { Connection = Connection };
            var result = await cmd.ExecuteAsync();

            return result;
        }

        public List<Category> GetCategoryTree(CategoryTreeParameters prm = null)
        {

            var cmd = new GetCategoryTreeCommand { Connection = Connection };
            var result = cmd.Execute(prm ?? new CategoryTreeParameters());

            return result;
        }

        public async Task<List<Category>> GetCategoryTreeAsync(CategoryTreeParameters prm = null)
        {

            var cmd = new GetCategoryTreeCommand { Connection = Connection };
            var result = await cmd.ExecuteAsync(prm ?? new CategoryTreeParameters());

            return result;
        }

        public List<CategoryAttribute> GetCategoryAttributes(CategoryAttributesParameters prm)
        {

            var cmd = new GetCategoryAttributesCommand { Connection = Connection };
            var result = cmd.Execute(prm);

            return result;
        }

        public async Task<List<CategoryAttribute>> GetCategoryAttributesAsync(CategoryAttributesParameters prm)
        {

            var cmd = new GetCategoryAttributesCommand { Connection = Connection };
            var result = await cmd.ExecuteAsync(prm);

            return result;
        }

        public List<AttributeValue> GetAttributeValues(AttributeValuesParameters prm)
        {

            var cmd = new GetAttributeValuesCommand { Connection = Connection };
            var result = cmd.Execute(prm);

            return result;
        }

        public async Task<List<AttributeValue>> GetAttributeValuesAsync(AttributeValuesParameters prm)
        {

            var cmd = new GetAttributeValuesCommand { Connection = Connection };
            var result = await cmd.ExecuteAsync(prm);

            return result;
        }

        public List<DeliveryMethod> GetDeliveryMethodList(DeliveryMethodListParameters pars)
        {
            var cmd = new GetDeliveryMethodListCommand { Connection = Connection };
            var result = cmd.Execute(pars);

            return result;
        }

        public async Task<List<DeliveryMethod>> GetDeliveryMethodListAsync(DeliveryMethodListParameters pars)
        {
            var cmd = new GetDeliveryMethodListCommand { Connection = Connection };
            var result = await cmd.ExecuteAsync(pars);

            return result;
        }
    }
}
