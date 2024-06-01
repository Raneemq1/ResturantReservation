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
        public DbSet<ReservationDetail> ReservationDetails {  get; set; }
        public DbSet<EmployeeResturantDetail> EmployeeResturantDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connectionString = config["SqlServerDb:connectionString"];
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Customer>().HasData(
               new Customer { CustomerId = 1, Email = "raneem@gmail.com", FirstName = "Raneem", LastName = "Alqadi", PhoneNumber = "059000000" },
               new Customer { CustomerId = 2, Email = "test1@gmail.com", FirstName = "Sarah", LastName = "Smith", PhoneNumber = "059000001" },
               new Customer { CustomerId = 3, Email = "test2@gmail.com", FirstName = "John", LastName = "Doe", PhoneNumber = "059000002" },
               new Customer { CustomerId = 4, Email = "test3@gmail.com", FirstName = "Jane", LastName = "Doe", PhoneNumber = "059000003" },
               new Customer { CustomerId = 5, Email = "test4@gmail.com", FirstName = "Emily", LastName = "Johnson", PhoneNumber = "059000004" }
             );

            modelBuilder.Entity<Resturant>().HasData(
                new Resturant { ResturantId = 1, Name = "Angelos", PhoneNumber = "0591231231", OpeningHours = "10-8", Address = "Ramallah" },
                new Resturant { ResturantId = 2, Name = "Pasta Place", PhoneNumber = "0591231232", OpeningHours = "9-9", Address = "Nablus" },
                new Resturant { ResturantId = 3, Name = "Pizza Palace", PhoneNumber = "0591231233", OpeningHours = "11-10", Address = "Jericho" },
                new Resturant { ResturantId = 4, Name = "Burger House", PhoneNumber = "0591231234", OpeningHours = "10-11", Address = "Hebron" },
                new Resturant { ResturantId = 5, Name = "Sushi World", PhoneNumber = "0591231235", OpeningHours = "12-12", Address = "Bethlehem" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Smith", ResturantId = 1, Position = "Manager" },
                new Employee { EmployeeId = 2, FirstName = "Alice", LastName = "Brown", ResturantId = 2, Position = "Chef" },
                new Employee { EmployeeId = 3, FirstName = "Bob", LastName = "White", ResturantId = 3, Position = "Waiter" },
                new Employee { EmployeeId = 4, FirstName = "Mary", LastName = "Jones", ResturantId = 4, Position = "Waitress" },
                new Employee { EmployeeId = 5, FirstName = "James", LastName = "Davis", ResturantId = 5, Position = "Manager" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, Capacity = 4, ResturantId = 1 },
                new Table { TableId = 2, Capacity = 2, ResturantId = 2 },
                new Table { TableId = 3, Capacity = 6, ResturantId = 3 },
                new Table { TableId = 4, Capacity = 8, ResturantId = 4 },
                new Table { TableId = 5, Capacity = 10, ResturantId = 5 }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, ResturantId = 1, CustomerId = 1, PartySize = 3, TableId = 1, ReservationDate = new DateTime(2024, 8, 12) },
                new Reservation { ReservationId = 2, ResturantId = 2, CustomerId = 2, PartySize = 2, TableId = 2, ReservationDate = new DateTime(2024, 8, 13) },
                new Reservation { ReservationId = 3, ResturantId = 3, CustomerId = 3, PartySize = 4, TableId = 3, ReservationDate = new DateTime(2024, 8, 14) },
                new Reservation { ReservationId = 4, ResturantId = 4, CustomerId = 4, PartySize = 5, TableId = 4, ReservationDate = new DateTime(2024, 8, 15) },
                new Reservation { ReservationId = 5, ResturantId = 5, CustomerId = 5, PartySize = 6, TableId = 5, ReservationDate = new DateTime(2024, 8, 16) }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, EmployeeId = 1, ReservationId = 1, TotalAmount = 20, OrderDate = new DateTime(2024, 7, 13) },
                new Order { OrderId = 2, EmployeeId = 2, ReservationId = 2, TotalAmount = 30, OrderDate = new DateTime(2024, 7, 14) },
                new Order { OrderId = 3, EmployeeId = 3, ReservationId = 3, TotalAmount = 40, OrderDate = new DateTime(2024, 7, 15) },
                new Order { OrderId = 4, EmployeeId = 4, ReservationId = 4, TotalAmount = 50, OrderDate = new DateTime(2024, 7, 16) },
                new Order { OrderId = 5, EmployeeId = 5, ReservationId = 5, TotalAmount = 60, OrderDate = new DateTime(2024, 7, 17) }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, ResturantId = 1, Name = "Potato", Description = "Crunchy", Price = 10 },
                new MenuItem { MenuItemId = 2, ResturantId = 2, Name = "Pasta", Description = "Cheesy", Price = 15 },
                new MenuItem { MenuItemId = 3, ResturantId = 3, Name = "Pizza", Description = "Delicious", Price = 20 },
                new MenuItem { MenuItemId = 4, ResturantId = 4, Name = "Burger", Description = "Juicy", Price = 25 },
                new MenuItem { MenuItemId = 5, ResturantId = 5, Name = "Sushi", Description = "Fresh", Price = 30 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 2, MenuItemId = 2, Quantity = 3 },
                new OrderItem { OrderItemId = 3, OrderId = 3, MenuItemId = 3, Quantity = 4 },
                new OrderItem { OrderItemId = 4, OrderId = 4, MenuItemId = 4, Quantity = 5 },
                new OrderItem { OrderItemId = 5, OrderId = 5, MenuItemId = 5, Quantity = 6 }
            );

            modelBuilder.Entity<ReservationDetail>().ToView("ReservationDetails").HasNoKey();
            modelBuilder.Entity<EmployeeResturantDetail>().ToView("EmployeeResturantDetails").HasNoKey();
        }
    }
}
