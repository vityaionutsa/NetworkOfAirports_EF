using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Interfaces
{
    public interface IFlightPassengerRepository
    {
        Task<(Guid, Guid)> CreateAsync(FlightPassenger entity);
        Task<PagedList<FlightPassenger>> GetAllAsync(FlightPassengerParameters parameters);
        Task<FlightPassenger?> GetByIdAsync(Guid EquipmentId, Guid ClassId);
        Task UpdateAsync(FlightPassenger entity);
        Task DeleteAsync(Guid EquipmentId, Guid ClassId);
    }
}
