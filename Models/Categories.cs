﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Categorie")]

        public string ProductType { get; set; }

        
    }
}
