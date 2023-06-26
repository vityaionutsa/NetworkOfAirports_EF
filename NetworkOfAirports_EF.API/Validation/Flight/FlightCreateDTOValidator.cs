using FluentValidation;
using NetworkOfAirports_EF.BLL.DTO;

namespace NetworkOfAirports_EF.API.Validation.Flight
{
    public class FlightCreateDTOValidator : AbstractValidator<FlightCreateDTO>
    {
        public FlightCreateDTOValidator()
        {
            RuleFor(entity => entity.AirlineId)
                 .NotEmpty().WithMessage("AirlineId is required");
            RuleFor(entity => entity.DepartureAirportId)
                .NotEmpty().WithMessage("DepartureAirportId is required");
            RuleFor(entity => entity.ArrivalAirportId)
                .NotEmpty().WithMessage("ArrivalAirportId is required");;
            RuleFor(entity => entity.DepartureDate)
                .NotEmpty().WithMessage("DepartureDate is required")
                .LessThan(entity => entity.ArrivalDate).WithMessage("DepartureDate must be before ArrivalDate");
            RuleFor(entity => entity.ArrivalDate)
                .NotEmpty().WithMessage("ArrivalDate is required")
                .GreaterThan(entity => entity.DepartureDate).WithMessage("ArrivalDate must be after DepartureDate");
        }
    }
}
