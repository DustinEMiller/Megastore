﻿using System;
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
    public class ApiFetchController : ApiController
    {

        private Helper twoTapHelper;

        public ApiFetchController() {
            twoTapHelper = new Helper();
        }

        public async Task<IEnumerable<object>> Get() {
            var result = await GetSeedData();
            return new object[] { result };
        }

        private async Task<object> GetSeedData() {
            using (HttpClient httpClient = new HttpClient()) {
                if (System.Diagnostics.Debugger.IsAttached == false) {
                    System.Diagnostics.Debugger.Launch();
                }

                var payload = new FilterParameters();
                payload.filter = new Filter();
                string json = JsonConvert.SerializeObject(payload);

                var response = httpClient.PostAsync(twoTapHelper.TwoTapURLCreator("filters"), new StringContent(json, Encoding.UTF8, "application/json")).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                // Trying to deserialize on type of FIlter source. This is not universal
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
        public async Task<IEnumerable<object>> Post([FromBody]dynamic data) {
            var result = await GetSeedData();

            return new object[] { result };
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}