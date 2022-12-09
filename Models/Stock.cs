using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Stock
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Produit")]
        public int ProduitId { get; set; }
        [ForeignKey("ProduitId")]
        public Produit Produit { get; set; }

        [Required]
        public string Couleur { get; set; }

        [Required]
        public int Quantite { get; set; }

        [Required]
        public float Pointure { get; set; }
    }
}
