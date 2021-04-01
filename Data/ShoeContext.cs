
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoePortal_ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace OnlineShoePortal_ECommerce.Data
{
    public class ShoeContext : IdentityDbContext<StoreUser>
    {
        public ShoeContext(DbContextOptions<ShoeContext> options): base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();
                //.HasData()

        }
    }
}
