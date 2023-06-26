using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters;
using NetworkOfAirports_EF.DAL.Expansion.Paging;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(DataContext dataContext, ISortHelper<Flight> sortHelper)
            : base(dataContext, sortHelper) { }

        public override async Task<Guid> CreateAsync(Flight entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.FlightId;
        }
        public override async Task<PagedList<Flight>> GetAllAsync(BaseParameters parameters)
        {
            var list = dbContext.Flights
                .AsNoTracking()
                .Include(x => x.Airline)
                .Include(x => x.DepartureAirport)
                .Include(x => x.DepartureAirport.City)
                .Include(x => x.DepartureAirport.City.Country)
                .Include(x => x.ArrivalAirport)
                .Include(x => x.ArrivalAirport.City)
                .Include(x => x.ArrivalAirport.City.Country);
            var sortList = sortHelper.ApplySort(list, parameters.OrderBy);
            return await Task.Run(() => PagedList<Flight>
                .ToPagedList(sortList, parameters.PageNumber, parameters.PageSize));
        }
        public override async Task<Flight?> GetByIdAsync(Guid id)
        {
            var entity = await dbContext.Flights
                .AsNoTracking()
                .Include(x => x.Airline)
                .Include(x => x.DepartureAirport)
                .Include(x => x.DepartureAirport.City)
                .Include(x => x.DepartureAirport.City.Country)
                .Include(x => x.ArrivalAirport)
                .Include(x => x.ArrivalAirport.City)
                .Include(x => x.ArrivalAirport.City.Country)
                .FirstOrDefaultAsync(x => x.FlightId == id);
            return entity;
        }
    }
}
