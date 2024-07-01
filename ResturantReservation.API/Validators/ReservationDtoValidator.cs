using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class ReservationDtoValidator:AbstractValidator<ReservationDto>
    {
        public ReservationDtoValidator() 
        {
            RuleFor(res=>res.CustomerId).NotEmpty();
            RuleFor(res=>res.ReservationDate).NotEmpty();
            RuleFor(res => res.CustomerId).NotEmpty();
            RuleFor(res=>res.TableId).NotEmpty();
            
        }    
    }
}
