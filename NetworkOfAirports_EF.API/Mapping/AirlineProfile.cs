using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Entitites;

namespace NetworkOfAirports_EF.API.Mapping
{
    public class AirlineProfile : Profile
    {
        public AirlineProfile()
        {
            CreateMap<Airline, AirlineDTO>()
                .ForMember(dest => dest.AirlineName, opt => opt.MapFrom(src => src.AirlineName));
            CreateMap<Airline, AirlineCreateDTO>()
                .ForMember(dest => dest.AirlineName, opt => opt.MapFrom(src => src.AirlineName))
                .ReverseMap();
            CreateMap<Airline, AirlineUpdateDTO>()
                .ForMember(dest => dest.AirlineId, opt => opt.MapFrom(src => src.AirlineId))
                .ForMember(dest => dest.AirlineName, opt => opt.MapFrom(src => src.AirlineName))
                .ReverseMap();
        }
    }
}
