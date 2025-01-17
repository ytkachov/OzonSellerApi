﻿using OzonSellerApi.Commands;
using OzonSellerApi.Enums;
using OzonSellerApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OzonSellerApi.ApiCommands
{
	[ApiPostCommand(Url = "/description-category/tree")]
	public class GetCategoryTreeCommand : ApiCommandBase<List<Category>>
	{
	}

    [ApiPostCommand(Url = "/description-category/attribute")]
    public class GetCategoryAttributesCommand : ApiCommandBase<List<CategoryAttribute>>
    {
    }

    [ApiPostCommand(Url = "/description-category/attribute/values")]
    public class GetAttributeValuesCommand : ApiCommandBase<List<AttributeValue>>
    {
    }

    [ApiPostCommand(Url = "/product/import", SchemaVersion = SchemaVersion.v3)]
    public class ProductImportCommand : ApiCommandBase<ImportTaskID>
    {
    }


    // did not test it
    [ApiPostCommand(Url = "/warehouse/list")]
	public class GetWarehouseListCommand : ApiCommandBase<List<Warehouse>>
	{
	}

	[ApiPostCommand(Url = "/delivery-method/list")]
	public class GetDeliveryMethodListCommand : ApiCommandBase<List<DeliveryMethod>>
	{
	}
}
