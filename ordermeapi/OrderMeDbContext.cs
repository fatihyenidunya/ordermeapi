using Microsoft.EntityFrameworkCore;
using ordermeapi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ordermeapi
{
    public class OrderMeDbContext : DbContext
    {

        public OrderMeDbContext(DbContextOptions<OrderMeDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.ProductCategoryId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category>  Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseSqlServer("Data Source=ordermedb.czphlh1kyqt0.us-east-1.rds.amazonaws.com;Initial Catalog=ordermedb;  user id=yenidunya;password=admin*1234; MultipleActiveResultSets=True;");

           
        }

    }
}
