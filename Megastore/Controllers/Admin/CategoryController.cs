using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megastore.Models;

namespace Megastore.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View("~/Views/Admin/Category/Index.cshtml");
        }

        public JsonResult Get() {
            List<Category> categories;
            List<Category> categoryTree;

            categories = _context.Categories.Where(c => c.ParentId == 0).Take(10).ToList();

            categoryTree = categories.
                Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    Children = GetChildren(categories, c.Id)
                }).ToList();

            return this.Json(categoryTree, JsonRequestBehavior.AllowGet);
        }

        private List<Category> GetChildren(List<Category> categories, int parentId) {
            return categories.Where(c => c.ParentId == parentId)
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    Children = GetChildren(categories, c.Id)
                }).ToList();
        }

    }
}