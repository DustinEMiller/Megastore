using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Megastore.Models
{
    [NotMapped]
    public class PagingInfo {
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}