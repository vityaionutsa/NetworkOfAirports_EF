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
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<Guid> CreateAsync(TEntity entity);
        Task<PagedList<TEntity>> GetAllAsync(BaseParameters parameters);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
