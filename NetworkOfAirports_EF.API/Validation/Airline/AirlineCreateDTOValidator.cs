using FluentValidation;
using NetworkOfAirports_EF.BLL.DTO;

namespace NetworkOfAirports_EF.API.Validation.Airline
{
    public class AirlineCreateDTOValidator : AbstractValidator<AirlineCreateDTO>
    {
        public AirlineCreateDTOValidator()
        {
            RuleFor(entity => entity.AirlineName)
                .NotEmpty().WithMessage("AirlineName is required")
                .MaximumLength(200).WithMessage("AirlineName must not exceed 200 characters");
        }
    }
}
