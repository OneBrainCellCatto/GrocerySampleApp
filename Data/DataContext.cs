using Grocery.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CivilStatus> CivilStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("Business");
            // View Mapping
            // Mapping to a view will remove default table mapping
            // Views will be used for queries
            // Table Mapping will be used for updates
            //modelBuilder.Entity<Employee>
            //    .ToView("employeeViews", schema: "Business");
        }
    }
}  
