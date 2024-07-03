using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
            (@"create proc CustomerReservationWithLargePartySize
            @size int as 
            select C.* from Customers C
            join Reservations R on C.CustomerId=R.CustomerId
            where R.PartySize>@size");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop proc CustomerReservationWithLargePartySize");
        }
    }
}
