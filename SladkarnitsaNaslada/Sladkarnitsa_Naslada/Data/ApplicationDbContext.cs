using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sladkarnitsa_Naslada.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Sladkarnitsa_Naslada.Models.Product;

namespace Sladkarnitsa_Naslada.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public object Designers { get; internal set; }
        public DbSet<Sladkarnitsa_Naslada.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }
        public DbSet<Sladkarnitsa_Naslada.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }
        public DbSet<Sladkarnitsa_Naslada.Models.Product.ProductEditVM> ProductEditVM { get; set; }
        public DbSet<Sladkarnitsa_Naslada.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }
        public DbSet<Sladkarnitsa_Naslada.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }
    }
}
