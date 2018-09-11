using System;
using System.Collections.Generic;
using System.Text;
using C2C.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace C2C.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Review> Review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
