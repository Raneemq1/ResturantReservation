using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ResturantReservation.Db.Models;

namespace ResturantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connectionString = config["SqlServerDb:connectionString"];
             if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
