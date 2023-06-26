using FluentValidation;
using NetworkOfAirports_EF.BLL.DTO;

namespace NetworkOfAirports_EF.API.Validation.FlightPassenger
{
    public class FlightPassengerCreateDTOValidator : AbstractValidator<FlightPassengerCreateDTO>
    {
        public FlightPassengerCreateDTOValidator()
        {
            RuleFor(entity => entity.FlightId)
                    .NotEmpty().WithMessage("FlightId is required");
            RuleFor(entity => entity.PassengerId)
                    .NotEmpty().WithMessage("PassengerId is required");
        }
    }
}
