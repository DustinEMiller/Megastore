using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Megastore.Models;
using TwoTap.Models;
using System.Data.Entity;
using System.Web.Routing;
using System.Web.Mvc;

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

        public RouteValueDictionary MergeIn(IDictionary<string, object> original_data, object more_data) {
            var result = new RouteValueDictionary(original_data);
            foreach (var k in HtmlHelper.ObjectToDictionary(more_data)) {
                result[k.Key] = k.Value;
            }
            return result;
        }

    }
}