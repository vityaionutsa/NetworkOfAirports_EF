using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;

namespace NetworkOfAirports_EF.API.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDTO>()
                .ConstructUsing((src, rc) => new FlightDTO
                {
                    FlightId = src.FlightId,
                    AirlineName = src.Airline.AirlineName,
                    DepartureAirportCode = src.DepartureAirport.AirportCode,
                    DepartureAirportName = src.DepartureAirport.AirportName,
                    DepartureAirportCountry = src.DepartureAirport.City.Country.CountryName,
                    ArrivalAirportCode = src.ArrivalAirport.AirportCode,
                    ArrivalAirportName = src.ArrivalAirport.AirportName,
                    ArrivalAirportCountry = src.ArrivalAirport.City.Country.CountryName,
                    DepartureAndArrivalDates = (src.DepartureDate, src.ArrivalDate)
                });
            CreateMap<Flight, FlightCreateDTO>()
                .ForMember(dest => dest.AirlineId, opt => opt.MapFrom(src => src.AirlineId))
                .ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirportId))
                .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirportId))
                .ForMember(dest => dest.DepartureDate, opt => opt.MapFrom(src => src.DepartureDate))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ReverseMap();
            CreateMap<Flight, FlightUpdateDTO>()
                .ForMember(dest => dest.FlightId, opt => opt.MapFrom(src => src.FlightId))
                .ForMember(dest => dest.AirlineId, opt => opt.MapFrom(src => src.AirlineId))
                .ForMember(dest => dest.DepartureAirportId, opt => opt.MapFrom(src => src.DepartureAirportId))
                .ForMember(dest => dest.ArrivalAirportId, opt => opt.MapFrom(src => src.ArrivalAirportId))
                .ForMember(dest => dest.DepartureDate, opt => opt.MapFrom(src => src.DepartureDate))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ReverseMap();
        }
    }
}
