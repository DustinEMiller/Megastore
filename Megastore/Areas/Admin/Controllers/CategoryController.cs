using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megastore.Models;

namespace Megastore.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db;

        public CategoryController() {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View("~/Views/Admin/Category/Index.cshtml");
        }

        [ChildActionOnly]
        public ActionResult CategoryTree() {
            List<Category> categories = new List<Category>();

            using (db) {
                categories = db.Categories.OrderBy(c => c.ParentId).ToList();
            }
            return PartialView("~/Views/Admin/Category/_CategoryTree.cshtml", categories);
        }

        public ActionResult CategoryInfo(int id) {
            var category = db.Categories.Single(c => c.Id == id);

            return PartialView("~/Views/Admin/Category/_CategoryInfo.cshtml", category);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category) {

            var cat = db.Categories.Single(c => c.Id == category.Id);
            cat.InMenu = cat.InMenu;

            db.SaveChanges();

            return PartialView("~/Views/Admin/Category/_CategoryInfo.cshtml", category);
        }

        public JsonResult Get() {
            List<Category> categories;
            List<Category> categoryTree;

            categories = db.Categories.Where(c => c.ParentId == 0).ToList();

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
            List<Category> cats;

            cats = db.Categories.Where(c => c.ParentId == parentId).ToList();

            return cats.
                Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentId,
                    Children = GetChildren(cats, c.Id)
                }).ToList();
        }

    }
}