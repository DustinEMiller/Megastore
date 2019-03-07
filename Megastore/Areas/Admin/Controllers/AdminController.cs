using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Megastore.Models;

namespace Megastore.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;

        public AdminController() {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            db.Dispose();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}