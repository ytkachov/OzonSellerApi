using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OzonSellerApi;
using OzonSellerApi.Enums;
using OzonSellerApi.Model;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var ApiService = OzonSellerApiService.Instance;
            ApiService.Configure("https://api-seller.ozon.ru", "", "");

            //var result = await ApiService.GetCategoryTreeAsync();
            //Debug.WriteLine(result.ToPrettyJson());

            //var r1 = await ApiService.GetCategoryAttributesAsync(new CategoryAttributesParameters() { CategoryID = 17027899, TypeID = 87458887 });
            //Debug.WriteLine(r1.ToPrettyJson());

            var r2 = await ApiService.GetAttributeValuesAsync(new AttributeValuesParameters() { CategoryID = 17027899, TypeID = 87458887, AttributeID = 5309, Limit=50 });
            Debug.WriteLine(r2.ToPrettyJson());

        }
    }
}
