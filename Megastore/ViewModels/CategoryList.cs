using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Megastore.Models;

namespace Megastore.ViewModels
{
    public class CategoryList
    {
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public FilterNavigation FilterNavigation { get; set; }
    }
}