using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfAirports_EF.DAL.Entitites;

namespace NetworkOfAirports_EF.BLL.Services
{
    public class FlightService : IFlightService
    {
        public FlightService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(FlightCreateDTO entity)
        {
            Flight flight = Mapper.Map<Flight>(entity);
            var id = await UnitOfWork.Flights.CreateAsync(flight);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Flights.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<FlightDTO>> GetAllAsync(FlightParameters parameters)
        {
            var list = await UnitOfWork.Flights.GetAllAsync(parameters);
            return Mapper.Map<IEnumerable<Flight>, IEnumerable<FlightDTO>>(list);
        }
        public async Task<FlightDTO?> GetAsync(Guid id)
        {
            Flight? flight = await UnitOfWork.Flights.GetByIdAsync(id);
            FlightDTO? flightDTO = Mapper.Map<FlightDTO?>(flight);
            return flightDTO;
        }
        public async Task UpdateAsync(FlightUpdateDTO entity)
        {
            Flight flight = Mapper.Map<Flight>(entity);
            await UnitOfWork.Flights.UpdateAsync(flight);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
