using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Megastore.Models;

namespace Megastore.ViewModels
{
    public class FilterNavigation {
        public List<Category> categories = new List<Category>();
        public List<Gender> genders = new List<Gender>();
        public List<Site> site_ids = new List<Site>();
        public List<Brand> brands = new List<Brand>();
        public List<Size> sizes = new List<Size>();
        public List<PriceRange> price_ranges = new List<PriceRange>();
        public string thing = "yes"; 

        private ApplicationDbContext db = new ApplicationDbContext();
        private string urlPath;
        private NameValueCollection queryDictionary;


        public FilterNavigation(string path) {
            urlPath = path;
            string queryString = new System.Uri(path).Query;
            queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);
        }

        public void populateWithoutCategories() {
            using (db) {
                genders = db.Genders.OrderBy(g => g.Name).ToList();
                site_ids = db.Sites.OrderBy(s => s.SiteId).ToList();
                brands = db.Brands.OrderBy(g => g.Name).ToList();
                sizes = db.Sizes.OrderBy(g => g.Name).ToList();
            }
        
        }
    }
}