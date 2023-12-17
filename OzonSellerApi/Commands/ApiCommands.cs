using OzonSellerApi.Commands;
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
    public class GetCategoryAttributesCommand : ApiCommandBase<List<CategoryAttributes>>
    {
    }

    [ApiPostCommand(Url = "/description-category/attribute/values")]
    public class GetAttributeValuesCommand : ApiCommandBase<List<AttributeValues>>
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
