using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Megastore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Boolean InMenu { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Children { get; set; }
    }
}