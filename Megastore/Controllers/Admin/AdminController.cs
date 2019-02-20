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
            return View();
        }
    }
}