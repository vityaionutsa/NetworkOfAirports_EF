using FluentValidation;
using NetworkOfAirports_EF.BLL.DTO;

namespace NetworkOfAirports_EF.API.Validation.Airport
{
    public class AirportCreateDTOValidator : AbstractValidator<AirportCreateDTO>
    {
        public AirportCreateDTOValidator()
        {
            RuleFor(entity => entity.AirportCode)
                .NotEmpty().WithMessage("AirportCode is required")
                .Length(14).WithMessage("AirportCode must be 14 characters long")
                .Matches(@"^\d{4}-\d{4}-\d{4}$").WithMessage("AirportCode must be in the format 'xxxx-xxxx-xxxx'"); ;
            RuleFor(entity => entity.AirportName)
                .NotEmpty().WithMessage("AirportName is required")
                .MaximumLength(100).WithMessage("AirportName must not exceed 100 characters");
            RuleFor(entity => entity.CityId)
                 .NotEmpty().WithMessage("CityId is required");
        }
    }
}
