using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view ReservationDetails as 
            select R.ReservationId,CONCAT(C.FirstName,' ',C.LastName) 
            as [CustomerName],E.Name as [ResturantName]
            from Reservations R
            join Customers C on R.CustomerId=C.CustomerId
            join Resturants E on R.ResturantId=E.ResturantId;");

            migrationBuilder.Sql(@"create view EmployeeResturantDetails as 
            select E.EmployeeId,CONCAT(E.FirstName,' ',E.LastName) as [EmployeeName],
            R.Name as [ResturantName], R.Address as [ResturantAddress]
            from Employees E
            join Resturants R on E.ResturantId=R.ResturantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view ReservationDetails");
            migrationBuilder.Sql(@"drop view EmployeeResturantDetails");
        }
    }
}
