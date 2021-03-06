﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Megastore.Models;
using System.Net.Http;
using Megastore.ViewModels;

namespace Megastore.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [ChildActionOnly]
        public ActionResult Menu() {
            List<Category> categories = new List<Category>();

            using (db) {
                categories = db.Categories.Where(c => c.ParentId == 0).OrderBy(c => c.Name).Take(12).ToList();
            }

            return PartialView("~/Views/Category/_CategoryMenu.cshtml", categories);
        }

        [ChildActionOnly]
        public ActionResult FilterNavigation(int? id) {
            var path = Request.Url.Scheme + "://" + Request.Url.Host;
            string queryString = new System.Uri(path).Query;
            var qs = Request.QueryString;

            FilterNavigation filterNavigation = new FilterNavigation();
            filterNavigation.queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);
            filterNavigation.categoryId = id;

            using (db) {
                filterNavigation.genders = db.Genders.OrderBy(g => g.Name).ToList();
                filterNavigation.site_ids = db.Sites.OrderBy(s => s.SiteId).ToList();
                filterNavigation.brands = db.Brands.OrderBy(g => g.Name).ToList();
                filterNavigation.sizes = db.Sizes.OrderBy(g => g.Name).ToList();
            }

            return PartialView("~/Views/Category/_Filters.cshtml", filterNavigation);
        }

        public async System.Threading.Tasks.Task<ActionResult> ListAsync(int? id, int? page, string brand, string size, string gender)
        {
            // TODO: Show current filters, ability to remove them
            // TODO: Input validation for paramters
            // TODO: Admin ability to change display name of filters, set filters shown, other filter configuration
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            // TODO: Look into using some sort of composition or factory for parameters
            FilterParameters filterParameter = new FilterParameters();
            if (page != null) {
                filterParameter.page = (int)page;
            }

            filterParameter.per_page = 18; // TODO: Make this a config item in admin or option in paging block
            filterParameter.filter = new Models.Filter();
            filterParameter.filter.categories = new List<object>();
            filterParameter.filter.categories.Add(category.Name);

            if (brand != null) {
                filterParameter.filter.brands = new List<object>();
                filterParameter.filter.brands.Add(brand);
            }

            if (size != null) {
                filterParameter.filter.sizes = new List<object>();
                filterParameter.filter.sizes.Add(size);
            }

            if (gender != null) {
                filterParameter.filter.genders = new List<object>();
                filterParameter.filter.genders.Add(gender);
            }

            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();
                dynamic productResponse = await productApi.Post(filterParameter);
                IEnumerable<Product> products = productResponse.Products;

                PagingInfo pagingInfo = new PagingInfo();
                pagingInfo.CurrentPageIndex = productResponse.CurrentPage;
                pagingInfo.PageCount = productResponse.Pages;
                pagingInfo.CurrentCategory = category.Id;

                var categoryList = new CategoryList { Category = category, Products = products, PagingInfo = pagingInfo };
                return View(categoryList);
            }
            
        }

        public async System.Threading.Tasks.Task<ActionResult> PostList(Megastore.Models.FilterParameters filterParameter) {
            using (HttpClient httpClient = new HttpClient()) {
                var productApi = new ProductFetchController();

                IEnumerable<Product> products = await productApi.Post(filterParameter); ;
                // This is just a string of the json result.
                return PartialView("~/Views/Product/_ProductList.cshtml", products);
            }
        }

    }
}
