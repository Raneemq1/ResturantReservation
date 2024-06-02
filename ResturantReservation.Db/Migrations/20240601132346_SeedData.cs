using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "raneem@gmail.com", "Raneem", "Alqadi", "059000000" },
                    { 2, "test1@gmail.com", "Sarah", "Smith", "059000001" },
                    { 3, "test2@gmail.com", "John", "Doe", "059000002" },
                    { 4, "test3@gmail.com", "Jane", "Doe", "059000003" },
                    { 5, "test4@gmail.com", "Emily", "Johnson", "059000004" }
                });

            migrationBuilder.InsertData(
                table: "Resturants",
                columns: new[] { "ResturantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ramallah", "Angelos", "10-8", "0591231231" },
                    { 2, "Nablus", "Pasta Place", "9-9", "0591231232" },
                    { 3, "Jericho", "Pizza Palace", "11-10", "0591231233" },
                    { 4, "Hebron", "Burger House", "10-11", "0591231234" },
                    { 5, "Bethlehem", "Sushi World", "12-12", "0591231235" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "ResturantId" },
                values: new object[,]
                {
                    { 1, "John", "Smith", "Manager", 1 },
                    { 2, "Alice", "Brown", "Chef", 2 },
                    { 3, "Bob", "White", "Waiter", 3 },
                    { 4, "Mary", "Jones", "Waitress", 4 },
                    { 5, "James", "Davis", "Manager", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "ResturantId" },
                values: new object[,]
                {
                    { 1, "Crunchy", "Potato", 10m, 1 },
                    { 2, "Cheesy", "Pasta", 15m, 2 },
                    { 3, "Delicious", "Pizza", 20m, 3 },
                    { 4, "Juicy", "Burger", 25m, 4 },
                    { 5, "Fresh", "Sushi", 30m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "ResturantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 3 },
                    { 4, 8, 4 },
                    { 5, 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "ResturantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, 2, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 3, 4, new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, 4, 5, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, 5, 6, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20 },
                    { 2, 2, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 30 },
                    { 3, 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 40 },
                    { 4, 4, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 50 },
                    { 5, 5, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 60 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 3 },
                    { 3, 3, 3, 4 },
                    { 4, 4, 4, 5 },
                    { 5, 5, 5, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "ResturantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "ResturantId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "ResturantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "ResturantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resturants",
                keyColumn: "ResturantId",
                keyValue: 5);
        }
    }
}
