using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;

namespace NetworkOfAirports_EF.API.Mapping
{
    public class FlightPassengerProfile : Profile
    {
        public FlightPassengerProfile()
        {
            CreateMap<FlightPassenger, FlightPassengerDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.PassengerId, opt => opt.MapFrom(src => src.PassengerId))
                .ForMember(dest => dest.FlightDepartureDate, opt => opt.MapFrom(src => src.Flight.DepartureDate))
                .ForMember(dest => dest.FlightArrivalDate, opt => opt.MapFrom(src => src.Flight.ArrivalDate))
                .ForMember(dest => dest.PassengerFirstName, opt => opt.MapFrom(src => src.Passenger.LastName))
                .ForMember(dest => dest.PassengerLastName, opt => opt.MapFrom(src => src.Passenger.LastName));
            CreateMap<FlightPassenger, FlightPassengerCreateDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.PassengerId, opt => opt.MapFrom(src => src.PassengerId))
                .ReverseMap();
            CreateMap<FlightPassenger, FlightPassengerUpdateDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.PassengerId, opt => opt.MapFrom(src => src.PassengerId))
                .ReverseMap();
        }
    }
}
