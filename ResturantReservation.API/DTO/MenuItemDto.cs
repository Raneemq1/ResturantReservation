using System.ComponentModel.DataAnnotations.Schema;

namespace ResturantReservation.API.DTO
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public int ResturantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public double Price { get; set; }
    }
}
