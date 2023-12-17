using Newtonsoft.Json;              
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OzonSellerApi.Model
{
	public class Category : IDEntity
	{
		[JsonProperty("category_id")]
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

	public class CategoryAttributes : IDEntity
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

	public class AttributeValues : IDEntity
	{
        [JsonProperty("info")]
        public string Info { get; set; }  // Дополнительное описание.

        [JsonProperty("picture")]
		public string Picture { get; set; } // Ссылка на изображение.

        [JsonProperty("value")]
        public string Value { get; set; } // Значение характеристики товара.
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
