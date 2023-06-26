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
    public class AirlineService : IAirlineService
    {
        public AirlineService(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfOfWork;
            Mapper = mapper;
        }
        private IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public async Task<Guid> CreateAsync(AirlineCreateDTO entity)
        {
            Airline airline = Mapper.Map<Airline>(entity);
            var id = await UnitOfWork.Airlines.CreateAsync(airline);
            await UnitOfWork.SaveChangesAsync();
            return id;
        }
        public async Task DeleteAsync(Guid id)
        {
            await UnitOfWork.Airlines.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<AirlineDTO>> GetAllAsync(AirlineParameters parameters)
        {
            var list = await UnitOfWork.Airlines.GetAllAsync(parameters);
            return Mapper.Map<IEnumerable<Airline>, IEnumerable<AirlineDTO>>(list);
        }
        public async Task<AirlineDTO?> GetAsync(Guid id)
        {
            Airline? airline = await UnitOfWork.Airlines.GetByIdAsync(id);
            AirlineDTO? airlineDTO = Mapper.Map<AirlineDTO?>(airline);
            return airlineDTO;
        }
        public async Task UpdateAsync(AirlineUpdateDTO entity)
        {
            Airline airline = Mapper.Map<Airline>(entity);
            await UnitOfWork.Airlines.UpdateAsync(airline);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
