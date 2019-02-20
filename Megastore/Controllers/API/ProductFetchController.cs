﻿using System;
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

        public async Task<IEnumerable<Product>> Get() {
            var result = await GetProductData();

            return result;
        }

        private async Task<IEnumerable<Product>> GetProductData() {
            using (HttpClient httpClient = new HttpClient()) {

                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("search"), new StringContent("", Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic productResponse = JsonConvert.DeserializeObject(responseContent);
                List<Product> products = new List<Product>();
              
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