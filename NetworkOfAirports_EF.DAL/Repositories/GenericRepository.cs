using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Helpers;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected GenericRepository(DataContext dbContext, ISortHelper<TEntity> sortHelper)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<TEntity>();
            this.sortHelper = sortHelper;
        }
        protected readonly DataContext dbContext;
        protected readonly DbSet<TEntity> entities;
        protected readonly ISortHelper<TEntity> sortHelper;

        public abstract Task<Guid> CreateAsync(TEntity entity);
        public virtual async Task<PagedList<TEntity>> GetAllAsync(BaseParameters parameters)
        {
            var list = entities.AsNoTracking();
            var sortList = sortHelper.ApplySort(list, parameters.OrderBy);
            return await Task.Run(() => PagedList<TEntity>
                .ToPagedList(sortList, parameters.PageNumber, parameters.PageSize));
        }
        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await entities.FindAsync(id);
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            entities.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity).Name} with id: [{id}] was not found");
            }
            await Task.Run(() => entities.Remove(entity));
            await dbContext.SaveChangesAsync();
        }
    }
}
