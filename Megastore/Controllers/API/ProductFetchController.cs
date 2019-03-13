using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Megastore.Models;
using Megastore.Helpers;

namespace Megastore.Controllers
{
    public class ProductFetchController : ApiController
    {
        private Helper twoTapHelper;

        public ProductFetchController() {
            twoTapHelper = new Helper();
        }

        public async Task<dynamic> Post(FilterParameters filter) {
            using (HttpClient httpClient = new HttpClient()) {
                
                string jsonFilter = JsonConvert.SerializeObject(filter);
                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("search"), new StringContent(jsonFilter, Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic productResponse = JsonConvert.DeserializeObject(responseContent);
                List<Product> products = new List<Product>();

                foreach (var p in productResponse.products) {
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

                //Search api endpoint only allows up to 10000 products returned. 
                //The scroll api endpoint does not work since it only holds the 
                //"next page" id for 30 seconds. So we are hitting a limitation here, 
                //thus the check here to limit going over

                int pages = productResponse.total / productResponse.per_page;

                if (productResponse.total > 10000) {
                    pages = 10000 / (int)productResponse.per_page;
                }

                dynamic productInfo = new
                {
                    Products = products,
                    Pages = pages,
                    CurrentPage = productResponse.page
                };

                return productInfo;
            }
        }
    }
}