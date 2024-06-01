﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturantReservation.Db;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResturantReservation.Db.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "raneem@gmail.com",
                            FirstName = "Raneem",
                            LastName = "Alqadi",
                            PhoneNumber = "059000000"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "test1@gmail.com",
                            FirstName = "Sarah",
                            LastName = "Smith",
                            PhoneNumber = "059000001"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "test2@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "059000002"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "test3@gmail.com",
                            FirstName = "Jane",
                            LastName = "Doe",
                            PhoneNumber = "059000003"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "test4@gmail.com",
                            FirstName = "Emily",
                            LastName = "Johnson",
                            PhoneNumber = "059000004"
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResturantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ResturantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "John",
                            LastName = "Smith",
                            Position = "Manager",
                            ResturantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Alice",
                            LastName = "Brown",
                            Position = "Chef",
                            ResturantId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Bob",
                            LastName = "White",
                            Position = "Waiter",
                            ResturantId = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Mary",
                            LastName = "Jones",
                            Position = "Waitress",
                            ResturantId = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "James",
                            LastName = "Davis",
                            Position = "Manager",
                            ResturantId = 5
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ResturantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("ResturantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Crunchy",
                            Name = "Potato",
                            Price = 10m,
                            ResturantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Cheesy",
                            Name = "Pasta",
                            Price = 15m,
                            ResturantId = 2
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Delicious",
                            Name = "Pizza",
                            Price = 20m,
                            ResturantId = 3
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Juicy",
                            Name = "Burger",
                            Price = 25m,
                            ResturantId = 4
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Fresh",
                            Name = "Sushi",
                            Price = 30m,
                            ResturantId = 5
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 1,
                            TotalAmount = 20
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 2,
                            TotalAmount = 30
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 3,
                            TotalAmount = 40
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 4,
                            TotalAmount = 50
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationId = 5,
                            TotalAmount = 60
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            MenuItemId = 2,
                            OrderId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 3,
                            MenuItemId = 3,
                            OrderId = 3,
                            Quantity = 4
                        },
                        new
                        {
                            OrderItemId = 4,
                            MenuItemId = 4,
                            OrderId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            OrderItemId = 5,
                            MenuItemId = 5,
                            OrderId = 5,
                            Quantity = 6
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResturantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ResturantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 3,
                            ReservationDate = new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResturantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResturantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResturantId = 3,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 5,
                            ReservationDate = new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResturantId = 4,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 6,
                            ReservationDate = new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResturantId = 5,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Resturant", b =>
                {
                    b.Property<int>("ResturantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResturantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResturantId");

                    b.ToTable("Resturants");

                    b.HasData(
                        new
                        {
                            ResturantId = 1,
                            Address = "Ramallah",
                            Name = "Angelos",
                            OpeningHours = "10-8",
                            PhoneNumber = "0591231231"
                        },
                        new
                        {
                            ResturantId = 2,
                            Address = "Nablus",
                            Name = "Pasta Place",
                            OpeningHours = "9-9",
                            PhoneNumber = "0591231232"
                        },
                        new
                        {
                            ResturantId = 3,
                            Address = "Jericho",
                            Name = "Pizza Palace",
                            OpeningHours = "11-10",
                            PhoneNumber = "0591231233"
                        },
                        new
                        {
                            ResturantId = 4,
                            Address = "Hebron",
                            Name = "Burger House",
                            OpeningHours = "10-11",
                            PhoneNumber = "0591231234"
                        },
                        new
                        {
                            ResturantId = 5,
                            Address = "Bethlehem",
                            Name = "Sushi World",
                            OpeningHours = "12-12",
                            PhoneNumber = "0591231235"
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("ResturantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("ResturantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            ResturantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 2,
                            ResturantId = 2
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 6,
                            ResturantId = 3
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 8,
                            ResturantId = 4
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 10,
                            ResturantId = 5
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Employee", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.Resturant", "Resturant")
                        .WithMany("Employees")
                        .HasForeignKey("ResturantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resturant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.MenuItem", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.Resturant", "Resturant")
                        .WithMany("MenuItems")
                        .HasForeignKey("ResturantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resturant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Order", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.OrderItem", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Reservation", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Models.Resturant", "Resturant")
                        .WithMany("Reservations")
                        .HasForeignKey("ResturantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Resturant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Table", b =>
                {
                    b.HasOne("ResturantReservation.Db.Models.Resturant", "Resturant")
                        .WithMany("Tables")
                        .HasForeignKey("ResturantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resturant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Resturant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("ResturantReservation.Db.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
