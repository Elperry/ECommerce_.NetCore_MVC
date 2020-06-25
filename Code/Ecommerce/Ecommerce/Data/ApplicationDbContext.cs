using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;
namespace Ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //to create the composite primary key for orderItems 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderItems>(ww =>
            {
                ww.HasKey(e => new { e.ProductId, e.OrderId }).HasName("Primary");
            });

            builder.Entity<SellingOrderItems>(ww =>
            {
                ww.HasKey(e => new { e.ProductId, e.SellingOrderId }).HasName("PrimarySelling");
            });
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<SellingOrder> SellingOrders { get; set; }
        public virtual DbSet<SellingOrderItems> SellingOrderItems { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }



    }
}
