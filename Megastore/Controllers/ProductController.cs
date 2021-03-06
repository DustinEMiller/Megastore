﻿using System;
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

        public async System.Threading.Tasks.Task<ActionResult> ProductPostList(Megastore.Models.FilterParameters filterParameter) {
            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();

                dynamic response = await productApi.Post(filterParameter);
                IEnumerable<Product> products = response.Products;
                // This is just a string of the json result.
                return PartialView("~/Views/Product/_ProductList.cshtml", products);
            }
        }
    }
}