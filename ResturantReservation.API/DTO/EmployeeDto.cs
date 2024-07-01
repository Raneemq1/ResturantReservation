namespace ResturantReservation.API.DTO
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public int ResturantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}
