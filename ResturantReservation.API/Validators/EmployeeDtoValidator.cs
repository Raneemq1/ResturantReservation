using FluentValidation;
using ResturantReservation.API.DTO;

namespace ResturantReservation.API.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(emp => emp.FirstName).NotEmpty();
            RuleFor(emp => emp.LastName).NotEmpty();
            RuleFor(emp => emp.Position).NotEmpty().Must(ValidPosition);
            RuleFor(emp => emp.ResturantId).NotEmpty();
        }

        private bool ValidPosition(string pos)
        {
            return Enum.TryParse(typeof(EmployeePosition), pos, true, out _);
        }
    }

}