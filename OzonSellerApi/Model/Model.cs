using Newtonsoft.Json;              
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OzonSellerApi.Model
{
    public class OzonAuth
    {
        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }

    public class Category : IDEntity
	{
		[JsonProperty("description_category_id")]
		public override long ID { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("type_name")]
        public string TypeName { get; set; } // Название типа товара.

        [JsonProperty("type_id")]
        public long TypeID { get; set; }    // Идентификатор типа товара.

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }  // true, если в категории нельзя создавать товары. false, если можно.

        [JsonProperty("children")]
        public Category[] Children { get; set; }

	}

	public class CategoryAttribute : IDEntity
	{
		[JsonProperty("description")]
        public string Description { get; set; }  // Описание характеристики.

        [JsonProperty("dictionary_id")]
		public long DictionaryID { get; set; }   // Идентификатор справочника.

        [JsonProperty("group_id")]
		public long GroupID { get; set; }        // Идентификатор группы характеристик.

        [JsonProperty("group_name")]
		public string GroupName { get; set; }    // Название группы характеристик.

        [JsonProperty("id")]
		public override long ID { get; set; }    // идентификатор атрибута.

        [JsonProperty("is_aspect")]
		public bool IsAspect { get; set; } // Признак аспектного атрибута. Аспектный атрибут — характеристика, по которой отличаются товары одной модели.
                                           // Например, у одежды и обуви одной модели могут быть разные расцветки и размеры. То есть цвет и размер — это аспектные атрибуты.
                                           // Значения поля:
                                           // 
                                           // true — атрибут аспектный и его нельзя изменить после поставки товара на склад или продажи со своего склада.
                                           // false — атрибут не аспектный, можно изменить в любое время.

        [JsonProperty("is_collection")]
		public bool IsCollection { get; set; } // true, если характеристика — набор значений.
                                               // false, если характеристика — одно значение.	   

        [JsonProperty("is_required")]
		public bool IsRequired { get; set; } // Признак обязательной характеристики:
                                             // true — обязательная характеристика,
                                             // false — характеристику можно не указывать.
        [JsonProperty("name")]
        public string Name { get; set; }     // Название.

        [JsonProperty("type")]
        public string TypeName { get; set; } // Тип характеристики.
    }

	public class AttributeValue : IDEntity
	{
        [JsonProperty("id")]
        public override long ID { get; set; }    // идентификатор значения атрибута.

        [JsonProperty("info")]
        public string Info { get; set; }  // Дополнительное описание.

        [JsonProperty("picture")]
		public string Picture { get; set; } // Ссылка на изображение.

        [JsonProperty("value")]
        public string Value { get; set; } // Значение характеристики товара.
    }

    public class ItemAttribuiteValue
    {
        [JsonProperty("dictionary_value_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ID { get; set; }    // идентификатор значения из словаря.

        [JsonProperty("value")]
        public object Value { get; set; }
    }

    public class ProductAttribute
    {
        [JsonProperty("id")]
        public long ID { get; set; }    // идентификатор значения атрибута.

        [JsonProperty("complex_id")]
        public long ComplexID { get; set; } = 0;

        [JsonProperty("values")]
        public ItemAttribuiteValue[] Values { get; set; }
    }

    public class ProductInfo : ApiMethodParamsBase
    {
        [JsonProperty("description_category_id")]
        public long CategoryID { get; set; }

        [JsonProperty("offer_id")]
        public string OfferID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("barcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Barcode { get; set; }

        [JsonProperty("depth")]
        public int Depth { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("dimension_unit")]
        public string DimensionUnit { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("weight_unit")]
        public string WeightUnit { get; set; }

        [JsonProperty("primary_image", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryImage { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Images { get; set; }

        [JsonProperty("images360", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Images360 { get; set; }

        [JsonProperty("color_image", NullValueHandling = NullValueHandling.Ignore)]
        public string ColorImage { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("old_price")]
        public string OldPrice { get; set; }

        [JsonProperty("premium_price")]
        public string PremiumPrice { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("vat")]
        public string VAT { get; set; }

        [JsonProperty("pdf_list")]
        public string PdfList { get; set; }

        [JsonProperty("attributes")]
        public ProductAttribute[] Attributes { get; set; }

        [JsonProperty("complex_attributes", NullValueHandling = NullValueHandling.Ignore)]
        public ProductAttribute[] ComplexAttributes { get; set; }
    }


    public class ImportTaskID
    {
        [JsonProperty("task_id")]
        public long TaskID { get; set; }
    }

    public class Warehouse : IDEntity
	{
		[JsonProperty("warehouse_id")]
		public override long ID { get; set; }
		public string Name { get; set; }

		[JsonProperty("is_rfbs")]
		public bool IsRFBS { get; set; }
	}

	public class DeliveryMethod : IDEntity
	{
		[JsonProperty("company_id")]
		public long CompanyID { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("cutoff")]
		public string Cutoff { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("provider_id")]
		public long ProviderID { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("template_id")]
		public long TemplateID { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("warehouse_id")]
		public long WarehouseID { get; set; }
	}

}
