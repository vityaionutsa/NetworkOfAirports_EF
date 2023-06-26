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
    public interface IAirportService
    {
        Task<Guid> CreateAsync(AirportCreateDTO entity);
        Task<AirportDTO?> GetAsync(Guid id);
        Task<IEnumerable<AirportDTO>> GetAllAsync(AirportParameters parameters);
        Task UpdateAsync(AirportUpdateDTO entity);
        Task DeleteAsync(Guid id);
    }
}
