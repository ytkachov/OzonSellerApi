using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OzonSellerApi;
using OzonSellerApi.Enums;
using OzonSellerApi.Model;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ozon_auth_str = File.ReadAllText(@"D:\Projects\Mayya Necklace\OzonSellerApi\ozon_seller_id.json");
            var ozon_auth = JsonToolkit.ParseAsJson<OzonAuth>(ozon_auth_str);

            var ApiService = OzonSellerApiService.Instance;
            ApiService.Configure("https://api-seller.ozon.ru", ozon_auth.ApiKey, ozon_auth.UserID);

            var result = ApiService.GetCategoryTree();
            Debug.WriteLine(result.ToPrettyJson());

            var r1 = ApiService.GetCategoryAttributes(new CategoryAttributesParameters() { CategoryID = 17027899, TypeID = 87458887 });
            Debug.WriteLine(r1.ToPrettyJson());

            foreach (var ca in r1)
            {
                if (ca.DictionaryID == 0 || ca.ID != 5309)
                    continue;

                Debug.WriteLine($"{ca.ID} : {ca.Name} // {ca.Description} --------------------------");

                long lastid = 0;
                int limit = 5000;
                while (true)
                {
                    var r2 = ApiService.GetAttributeValues(new AttributeValuesParameters() { CategoryID = 17027899, TypeID = 87458887, AttributeID = ca.ID, Limit = limit, LastValueID = lastid });
                    Debug.WriteLine(r2.ToPrettyJson());

                    if (r2.Count < limit)
                        break;

                    lastid = r2[r2.Count - 1].ID;
                }
            }
        }
    }
}
