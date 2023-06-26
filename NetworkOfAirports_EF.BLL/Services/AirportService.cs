using AutoMapper;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.Services
{
    public class AirportService : IAirportService
    {
        public AirportService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(AirportCreateDTO entity)
        {
            Airport airport = Mapper.Map<Airport>(entity);
            var id = await UnitOfWork.Airports.CreateAsync(airport);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Airports.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<AirportDTO>> GetAllAsync(AirportParameters parameters)
        {
            var list = await UnitOfWork.Airports.GetAllAsync(parameters);
            return Mapper.Map<IEnumerable<Airport>, IEnumerable<AirportDTO>>(list);
        }
        public async Task<AirportDTO?> GetAsync(Guid id)
        {
            Airport? airport = await UnitOfWork.Airports.GetByIdAsync(id);
            AirportDTO? airportDTO = Mapper.Map<AirportDTO?>(airport);
            return airportDTO;
        }
        public async Task UpdateAsync(AirportUpdateDTO entity)
        {
            Airport airport = Mapper.Map<Airport>(entity);
            await UnitOfWork.Airports.UpdateAsync(airport);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
