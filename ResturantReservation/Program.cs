using ResturantReservation.Db;
using ResturantReservation.Db.Repositories;

Console.WriteLine("Resturant Reservation!");
RestaurantReservationDbContext context = new();


OrderRepository orderRepo=new(context);
var orderedMenuItems = await orderRepo.ListOrderedMenuItems(1);
foreach (var item in orderedMenuItems)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine(await orderRepo.CalculateAverageOrderAmount(1));

EmployeeRepository empRepo = new(context);
var empsResturantItems = await empRepo.EmployeeAndResturantDetails();
foreach(var item in empsResturantItems)
{
    Console.WriteLine(item.EmployeeName+item.ResturantName);
}