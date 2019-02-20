using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using Megastore.Models;

namespace Megastore.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> Index() {
            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();

                IEnumerable<Product> products = await productApi.Get();
                ViewBag.Message = "Your application description page.";
                // This is just a string of the json result.
                return View(products);
            }
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}