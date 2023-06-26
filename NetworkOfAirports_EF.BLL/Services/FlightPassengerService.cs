using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.Services
{
    public class FlightPassengerService : IFlightPassengerService
    {
        public FlightPassengerService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<(Guid, Guid)> CreateAsync(FlightPassengerCreateDTO entity)
        {
            FlightPassenger FlightPassenger = Mapper.Map<FlightPassenger>(entity);
            var id = await UnitOfWork.FlightPassengers.CreateAsync(FlightPassenger);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid FlightId, Guid PassengerId)
        {
            await UnitOfWork.FlightPassengers.DeleteAsync(FlightId, PassengerId);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<FlightPassengerDTO>> GetAllAsync(FlightPassengerParameters parameters)
        {
            var list = await UnitOfWork.FlightPassengers.GetAllAsync(parameters);
            return Mapper.Map<IEnumerable<FlightPassenger>, IEnumerable<FlightPassengerDTO>>(list);
        }
        public async Task<FlightPassengerDTO?> GetAsync(Guid FlightId, Guid PassengerId)
        {
            FlightPassenger? flightPassenger = await UnitOfWork.FlightPassengers.GetByIdAsync(FlightId, PassengerId);
            FlightPassengerDTO? flightPassengerDTO = Mapper.Map<FlightPassengerDTO?>(flightPassenger);
            return flightPassengerDTO;
        }
        public async Task UpdateAsync(FlightPassengerUpdateDTO entity)
        {
            FlightPassenger FlightPassenger = Mapper.Map<FlightPassenger>(entity);
            await UnitOfWork.FlightPassengers.UpdateAsync(FlightPassenger);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
