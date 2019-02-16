﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Megastore.Models
{
    public class Site
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string SiteId { get; set; }
    }
}