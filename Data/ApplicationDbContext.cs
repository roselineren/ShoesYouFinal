using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Produit> Produit { get; set; }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Produit2> Produit2 { get; set; }

        public DbSet<Stock2> Stock2 { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
