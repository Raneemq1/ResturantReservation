using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantReservation.Db.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; } 
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        [Column(TypeName ="decimal(6,2)")]
        public double Price { get; set; }
    }
}
