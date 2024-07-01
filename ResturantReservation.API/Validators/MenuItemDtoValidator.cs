using FluentValidation;
using ResturantReservation.API.DTO;
using ResturantReservation.Db.Models;

namespace ResturantReservation.API.Validators
{
    public class MenuItemDtoValidator:AbstractValidator<MenuItemDto>
    {
        public MenuItemDtoValidator() 
        {
            RuleFor(item=>item.Name).NotEmpty();
            RuleFor(item=>item.Description).NotEmpty();
            RuleFor(item=>item.Price).NotEmpty();
        }
    }
}
