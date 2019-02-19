using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Megastore.Models
{
    public class Product
    {
        public string Url { get; set; }
        public string Title { get; set; }
        //Map to Brand model
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string SiteName { get; set; }
    }
}