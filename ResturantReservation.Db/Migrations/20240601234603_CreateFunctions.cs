using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateFunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
               (@"create function fn_TotalRevenueOfResturant(@resturantId int)
                returns int 
                as 
                begin 
                declare @total int 
                select @total=SUM(M.Price*O.Quantity) from MenuItems M
                join OrderItems O on M.MenuItemId=O.OrderItemId
                where M.ResturantId=@resturantId;
                return @total
                end");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop function fn_TotalRevenueOfResturant");
        }
    }
}
