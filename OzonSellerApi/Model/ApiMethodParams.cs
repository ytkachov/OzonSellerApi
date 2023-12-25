using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonSellerApi.Model
{
	public class ApiMethodParamsBase : EntityBase
	{
		[JsonProperty("language")]
		public string Language { get; set; } = "RU";
	}

	/// <summary>
	/// Adds root "Filter" element into json request
	/// </summary>
	public class ApiMethodParamsWithFilter<TFilter> : ApiMethodParamsBase
		where TFilter : RequestFilterBase
	{
		public TFilter Filter { get; set; }

	}

    public class CategoryTreeParameters : ApiMethodParamsBase
    {
    }

    public class CategoryAttributesParameters : ApiMethodParamsBase
    {
        [JsonProperty("description_category_id")]
        public long CategoryID { get; set; }

        [JsonProperty("type_id")]
        public long TypeID { get; set; }
    }

    public class AttributeValuesParameters : ApiMethodParamsBase
    {
        [JsonProperty("description_category_id")]
        public long CategoryID { get; set; }

        [JsonProperty("type_id")]
        public int TypeID { get; set; }

        [JsonProperty("attribute_id")]
        public long AttributeID { get; set; }

        [JsonProperty("last_value_id")]
        public long LastValueID { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; } = 5000;
    }

    public class DeliveryMethodListParameters : ApiMethodParamsWithFilter<DeliveryMethodListFilter>
	{
		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("limit")]
		public int Limit { get; set; }
	}

	public class ApiMethodParamsSimple : ApiMethodParamsBase
	{
		public int Page { get; set; }

		public int PageSize { get; set; }
	}
}
