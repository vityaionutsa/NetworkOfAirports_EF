using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.Interfaces
{
    public interface IFlightService
    {
        Task<Guid> CreateAsync(FlightCreateDTO entity);
        Task<FlightDTO?> GetAsync(Guid id);
        Task<IEnumerable<FlightDTO>> GetAllAsync(FlightParameters parameters);
        Task UpdateAsync(FlightUpdateDTO entity);
        Task DeleteAsync(Guid id);
    }
}
