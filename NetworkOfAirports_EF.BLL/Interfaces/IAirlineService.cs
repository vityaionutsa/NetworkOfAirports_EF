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
    public interface IAirlineService
    {
        Task<Guid> CreateAsync(AirlineCreateDTO entity);
        Task<AirlineDTO?> GetAsync(Guid id);
        Task<IEnumerable<AirlineDTO>> GetAllAsync(AirlineParameters parameters);
        Task UpdateAsync(AirlineUpdateDTO entity);
        Task DeleteAsync(Guid id);
    }
}
