using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Megastore.Models
{
    [NotMapped]
    public class FilterNavigation {
        public List<Category> categories = new List<Category>();
        public List<Gender> genders = new List<Gender>();
        public List<Site> site_ids = new List<Site>();
        public List<Brand> brands = new List<Brand>();
        public List<Size> sizes = new List<Size>();
        public List<PriceRange> price_ranges = new List<PriceRange>();

        private ApplicationDbContext db = new ApplicationDbContext();


        public void populateWithoutCategories() {
            using (db) {
                genders = db.Genders.ToList();
                site_ids = db.Sites.ToList();
                brands = db.Brands.ToList();
                sizes = db.Sizes.ToList();
            }
        
        }
    }
}