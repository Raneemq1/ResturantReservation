using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class TableDtoValidator:AbstractValidator<TableDto>
    {
        public TableDtoValidator() 
        {
            RuleFor(table=>table.Capacity).NotEmpty();
            RuleFor(table=>table.ResturantId).NotEmpty();
        }
    }
}
