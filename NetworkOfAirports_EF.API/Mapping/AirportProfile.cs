using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;

namespace NetworkOfAirports_EF.API.Mapping
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMap<Airport, AirportDTO>()
                .ForMember(dest => dest.AirportCode, opt => opt.MapFrom(src => src.AirportCode))
                .ForMember(dest => dest.AirportName, opt => opt.MapFrom(src => src.AirportName))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.CountryName));
            CreateMap<Airport, AirportCreateDTO>()
                .ForMember(dest => dest.AirportCode, opt => opt.MapFrom(src => src.AirportCode))
                .ForMember(dest => dest.AirportName, opt => opt.MapFrom(src => src.AirportName))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ReverseMap();
            CreateMap<Airport, AirportUpdateDTO>()
                .ForMember(dest => dest.AirportId, opt => opt.MapFrom(src => src.AirportId))
                .ForMember(dest => dest.AirportCode, opt => opt.MapFrom(src => src.AirportCode))
                .ForMember(dest => dest.AirportName, opt => opt.MapFrom(src => src.AirportName))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ReverseMap();
        }
    }
}
