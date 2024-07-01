using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class CustomerDtoValidator: AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator() { 
        
            RuleFor(customer=>customer.FirstName).NotEmpty();
            RuleFor(customer=>customer.LastName).NotEmpty();
            RuleFor(customer=>customer.Email).NotEmpty();
            RuleFor(customer=>customer.PhoneNumber).NotEmpty();
        }
    }
}
