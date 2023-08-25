using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfExamples
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers {get; set; } // tables to load in 
        public DbSet<Order> Orders {get; set; } // tables to load in 
        public DbSet<Orderline> OrderLines { get; set; }

        public AppDbContext() { } // default constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "server=localhost\\sqlexpress; " +
            "database=SalesDb; " +
            "trusted_connection=true; " +
            "trustServerCertificate=true; ";
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
