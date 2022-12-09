using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Produit
    {

        public int Id { get; set; }
        [Required]

        public string Nom { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        //public int Price { get; set; }
        public string Image { get; set; }

        [Required]
        [Display(Name = "Categorie")]

        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public Categories ProductTypes { get; set; }
    }
}
