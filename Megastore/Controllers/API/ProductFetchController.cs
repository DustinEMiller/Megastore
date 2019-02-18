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

namespace Megastore.Controllers.API
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
                if (System.Diagnostics.Debugger.IsAttached == false) {
                    System.Diagnostics.Debugger.Launch();
                }
                var payload = new FilterParameters();
                payload.filter = new Filter();
                string json = JsonConvert.SerializeObject(payload);

                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("products/search"), new StringContent(json, Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<FilterSource>(responseContent);

                try {
                    list.PopulateFilters();
                }
                catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }

                return responseContent;
            }
        }
    }
}