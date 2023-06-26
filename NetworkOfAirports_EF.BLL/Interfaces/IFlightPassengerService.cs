using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.Interfaces
{
    public interface IFlightPassengerService
    {
        Task<(Guid, Guid)> CreateAsync(FlightPassengerCreateDTO entity);
        Task<FlightPassengerDTO?> GetAsync(Guid FlightId, Guid PassengerId);
        Task<IEnumerable<FlightPassengerDTO>> GetAllAsync(FlightPassengerParameters parameters);
        Task UpdateAsync(FlightPassengerUpdateDTO entity);
        Task DeleteAsync(Guid FlightId, Guid PassengerId);
    }
}
