using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using LifeLine.Models;

namespace LifeLine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ProductListings> ProductListings { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
