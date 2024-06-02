namespace ResturantReservation.Db.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public List<Order> Orders { get; set; }

    }
}
