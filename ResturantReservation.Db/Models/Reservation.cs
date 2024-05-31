namespace ResturantReservation.Db.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; } 
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }    
    }
}
