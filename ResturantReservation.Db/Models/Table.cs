namespace ResturantReservation.Db.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }    
        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set;}
    }
}
