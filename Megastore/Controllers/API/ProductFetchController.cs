using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using System.Text;
using Megastore.Models;
using System.Data.Entity;
using Megastore.Helpers;
using TwoTap.Models;
using System.Diagnostics;

namespace Megastore.Controllers
{
    public class ProductFetchController : ApiController
    {
        private Helper twoTapHelper;

        public ProductFetchController() {
            twoTapHelper = new Helper();
        }

        public async Task<IEnumerable<object>> Get() {
            var result = await GetProductData();

            return new object[] { result };
        }

        private async Task<object> GetProductData() {
            using (HttpClient httpClient = new HttpClient()) {

                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("search"), new StringContent("", Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic productResponse = JsonConvert.DeserializeObject(responseContent);
                var products = new List<Product>();
              
                foreach(var p in productResponse.products) {
                    products.Add(new Product()
                    {
                        Url = p.url,
                        Title = p.title,
                        Brand = p.brand,
                        Description = p.description,
                        Image = p.image,
                        Price = p.price,
                        SiteName = p.site_name
                    });
                }

                return products;
            }
        }
    }
}