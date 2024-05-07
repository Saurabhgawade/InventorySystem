using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace projectDemo.Data
{
    public class projectDemoContext : IdentityDbContext
    {
        public projectDemoContext (DbContextOptions<projectDemoContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory.Models.Product> Product { get; set; } = default!;
        public DbSet<Inventory.Models.Category> Category { get; set; } = default!;
        public DbSet<Inventory.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<Inventory.Models.Order> Order { get; set; } = default!;
        public DbSet<Inventory.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Inventory.Models.Sales> Sales { get; set; } = default!;
    }
}
