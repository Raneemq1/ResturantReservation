using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class ResturantDtoValidator:AbstractValidator<ResturantDto>
    {
        public ResturantDtoValidator() 
        {
            RuleFor(res=>res.Address).NotEmpty();
            RuleFor(res=>res.Name).NotEmpty();
            RuleFor(res=>res.PhoneNumber).NotEmpty();
            RuleFor(res=>res.OpeningHours).NotEmpty();
        }
    }
}
