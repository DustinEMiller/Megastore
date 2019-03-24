using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Megastore.Models;

namespace Megastore.ViewModels
{
    public class FilterNavigation {
        public List<Category> categories { get; set; }
        public List<Gender> genders { get; set; }
        public List<Site> site_ids { get; set; }
        public List<Brand> brands { get; set; }
        public List<Size> sizes { get; set; }
        public List<PriceRange> price_ranges { get; set; }
        public NameValueCollection queryDictionary { get; set; }
        public int? categoryId { get; set; }
    }
}