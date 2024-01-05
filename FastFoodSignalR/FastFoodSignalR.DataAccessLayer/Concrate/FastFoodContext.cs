using FastFoodSignalR.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodSignalR.DataAccessLayer.Concrate
{
    public class FastFoodContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-CH9SD0T; initial Catalog=FastFoodSignalR_DB_test;Integrated Security=true");

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<Slider> Sliders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>().HasKey(x => x.SliderID);
            modelBuilder.Entity<About>().HasKey(x => x.AboutID);
            modelBuilder.Entity<Booking>().HasKey(x => x.BookindID);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
            modelBuilder.Entity<Product>().HasKey(x => x.ProductID);
            modelBuilder.Entity<Discount>().HasKey(x => x.DiscountID);
            modelBuilder.Entity<Feature>().HasKey(x => x.FeauteID);
            modelBuilder.Entity<SocialMedia>().HasKey(x => x.SocialMediaID);
            modelBuilder.Entity<Testimonial>().HasKey(x => x.TestimonialID);
            modelBuilder.Entity<Order>().HasKey(x => x.OrderID);
            modelBuilder.Entity<MoneyCase>().HasKey(x => x.MoneyCaseID);
            modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderDetailID, x.ProductID, x.OrderID });

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
           .WithMany(x => x.Products)
           .HasForeignKey(x => x.CategoryID);


            modelBuilder.Entity<Product>()
                .HasOne(x => x.discount)
            .WithMany()
            .HasForeignKey(x => x.DiscountID);
            // .HasPrincipalKey(x => x.DiscountID);


            modelBuilder.Entity<OrderDetail>().
                HasOne(x => x.product)
                .WithMany(x => x.orderDetails)
                .HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<OrderDetail>().
                HasOne(x => x.order)
              .WithMany(x => x.orderDetails)
              .HasForeignKey(x => x.OrderID);




        }
    }

}
