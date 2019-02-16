using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Megastore.Models;
using TwoTap.Models;
using System.Data.Entity;

namespace Megastore.Helpers
{
    public class Helper
    {
        private ApplicationDbContext _context;

        public Helper() {
            _context = new ApplicationDbContext();
        }

        public string TwoTapURLCreator(string segment) {
            return ConfigurationManager.AppSettings["TwoTapURL"].ToString() + segment +"?"+ ConfigurationManager.AppSettings["TwoTapToken"].ToString();
        }

    }
}