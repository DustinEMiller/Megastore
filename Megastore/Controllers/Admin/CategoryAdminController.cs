using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megastore.Models;

namespace Megastore.Controllers.Admin
{
    public class CategoryAdminController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryAdminController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get() {
            List<Category> categories;

            categories = _context.Categories.Where(c => c.ParentId == 0).Take(10).
                Select(c => new Category
                {

                }).ToList();

            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }

    }
}