using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class OrderDtoValidator:AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(order=>order.OrderDate).NotEmpty();
            RuleFor(order=>order.EmployeeId).NotEmpty();
            RuleFor(order=>order.TotalAmount).NotEmpty();
        }
    }
}
