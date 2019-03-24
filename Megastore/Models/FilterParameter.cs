using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Megastore.Models
{

    public class FilterParameters
    {
        public Filter filter { get; set; }
        public int size { get; set; }
        public string destination_country { get; set; }
        public string scroll_id { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public string session { get; set; }
        public string product_attributes_format { get; set; }
        public string sort { get; set; }
    }

    public class Filter
    {
        public string keywords { get; set; }
        public List<object> keywords_fields { get; set; }
        public List<object> categories { get; set; }
        public List<object> genders { get; set; }
        public List<object> site_ids { get; set; }
        public List<object> brands { get; set; }
        public List<object> sizes { get; set; }
        public List<PriceRange> price_ranges { get; set; }
        public int intl_enabled { get; set; }
        public int approved { get; set; }
    }

    public class PriceRange
    {
        public int from { get; set; }
        public int to { get; set; }
        public string currency { get; set; }
    }

}