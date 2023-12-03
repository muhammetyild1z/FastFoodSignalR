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
            optionsBuilder.UseSqlServer("server=DESKTOP-CH9SD0T; initial Catalog=FastFoodSignalR_DB;Integrated Security=true");

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>().HasKey(x => x.AboutID);
            modelBuilder.Entity<Booking>().HasKey(x => x.BookindID);

           modelBuilder.Entity<Category>().HasKey(x => x.CategoryID);
           

            modelBuilder.Entity<Discount>().HasKey(x => x.DiscountID);
            modelBuilder.Entity<Feature>().HasKey(x => x.FeauteID);

            modelBuilder.Entity<Product>().HasKey(x => new {x.ProductID, x.CategoryID});
            modelBuilder.Entity<Product>().HasOne(x => x.Category)
               .WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<SocialMedia>().HasKey(x => x.SocialMediaID);
            modelBuilder.Entity<Testimonial>().HasKey(x => x.TestimonialID);
            
        }
    }

}
