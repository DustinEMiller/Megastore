using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Megastore.Models;

namespace Megastore.Controllers
{
    public class ProductController : Controller
    {

        public async System.Threading.Tasks.Task<ActionResult> ProductList() { 
            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();

                IEnumerable<Product> products = await productApi.Get();;
                // This is just a string of the json result.
                return PartialView("~/Views/Product/_ProductList.cshtml", products);
            }
        }

        public async System.Threading.Tasks.Task<ActionResult> ProductPostList(Megastore.Models.Filter filter) {
            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();

                IEnumerable<Product> products = await productApi.Post(filter); ;
                // This is just a string of the json result.
                return PartialView("~/Views/Product/_ProductList.cshtml", products);
            }
        }
    }
}