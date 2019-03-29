using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMigrationsCodeFirst.Models
{
    public class TestDatabaseContext: DbContext
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
           : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
