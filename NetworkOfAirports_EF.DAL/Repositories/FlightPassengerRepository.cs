using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Helpers;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public class FlightPassengerRepository : IFlightPassengerRepository
    {
        public FlightPassengerRepository(DataContext dbContext, ISortHelper<FlightPassenger> sortHelper)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<FlightPassenger>();
            this.sortHelper = sortHelper;
        }
        private readonly DataContext dbContext;
        private readonly DbSet<FlightPassenger> entities;
        private readonly ISortHelper<FlightPassenger> sortHelper;

        public async Task<(Guid, Guid)> CreateAsync(FlightPassenger entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return (entity.FlightId, entity.PassengerId);
        }
        public async Task<PagedList<FlightPassenger>> GetAllAsync(FlightPassengerParameters parameters)
        {
            var list = entities
                .AsNoTracking()
                .Include(x => x.Flight)
                .Include(x => x.Passenger);
            var sortList = sortHelper.ApplySort(list, parameters.OrderBy);
            return await Task.Run(() => PagedList<FlightPassenger>
                .ToPagedList(sortList, parameters.PageNumber, parameters.PageSize));
        }
        public async Task<FlightPassenger?> GetByIdAsync(Guid FlightId, Guid PassengerId)
        {
            return await entities
                .AsNoTracking()
                .Include(x => x.Flight)
                .Include(x => x.Passenger)
                .FirstOrDefaultAsync(x => x.FlightId == FlightId && x.PassengerId == PassengerId);
        }
        public async Task UpdateAsync(FlightPassenger entity)
        {
            entities.Update(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid FlightId, Guid PassengerId)
        {
            var entity = await GetByIdAsync(FlightId, PassengerId);
            if (entity == null)
            {
                throw new Exception($"{typeof(FlightPassenger).Name} with id: [{FlightId} : {PassengerId}] was not found");
            }
            await Task.Run(() => entities.Remove(entity));
            await dbContext.SaveChangesAsync();
        }
    }
}
