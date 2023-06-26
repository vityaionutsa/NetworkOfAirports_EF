using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public class AirportRepository : GenericRepository<Airport>, IAirportRepository
    {
        public AirportRepository(DataContext dataContext, ISortHelper<Airport> sortHelper)
            : base(dataContext, sortHelper) { }

        public override async Task<Guid> CreateAsync(Airport entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.AirportId;
        }
        public override async Task<PagedList<Airport>> GetAllAsync(BaseParameters parameters)
        {
            var list = dbContext.Airports
                .AsNoTracking()
                .Include(x => x.City)
                .Include(x => x.City.Country);
            var sortList = sortHelper.ApplySort(list, parameters.OrderBy);
            return await Task.Run(() => PagedList<Airport>
                .ToPagedList(sortList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Airport?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Airports
                .AsNoTracking()
                .Include(x => x.City)
                .Include(x => x.City.Country)
                .FirstOrDefaultAsync(x => x.AirportId == id);
            return entity;
        }
    }
}
