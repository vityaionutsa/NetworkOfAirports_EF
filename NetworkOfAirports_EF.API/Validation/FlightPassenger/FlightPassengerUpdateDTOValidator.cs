using FluentValidation;
using NetworkOfAirports_EF.BLL.DTO;

namespace NetworkOfAirports_EF.API.Validation.FlightPassenger
{
    public class FlightPassengerUpdateDTOValidator : AbstractValidator<FlightPassengerUpdateDTO>
    {
        public FlightPassengerUpdateDTOValidator()
        {
            RuleFor(entity => entity.FlightId)
                    .NotEmpty().WithMessage("FlightId is required");
            RuleFor(entity => entity.PassengerId)
                    .NotEmpty().WithMessage("PassengerId is required");
        }
    }
}
