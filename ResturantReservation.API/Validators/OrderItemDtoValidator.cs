using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class OrderItemDtoValidator:AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator() 
        {
            RuleFor(order=>order.OrderId).NotEmpty();
            RuleFor(order=>order.MenuItemId).NotEmpty();
            RuleFor(order=>order.Quantity).NotEmpty();
        }
    }
}
