using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ProductsController : ApiController
    {

        private Helper twoTapHelper;

        public ProductsController() {
            twoTapHelper = new Helper();
        }

        //[Authorize(Roles = RoleName.CanManageMovies)]
        public async Task<IEnumerable<object>> Get() {
            var result = await GetProductSearch();

            return new object[] { result };
        }

        private async Task<object> GetProductSearch() {
            using (HttpClient httpClient = new HttpClient()) {
                if (System.Diagnostics.Debugger.IsAttached == false) {
                    System.Diagnostics.Debugger.Launch();
                }
                var payload = new ProductParameters();
                payload.filter = new Filter();
                string json = JsonConvert.SerializeObject(payload);

                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("filters"), new StringContent(json, Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<FilterSource>(responseContent);

                try {
                    list.PopulateFilters();
                } catch (Exception e) {
                    Debug.WriteLine(e.ToString());
                }
                
                return responseContent;
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}