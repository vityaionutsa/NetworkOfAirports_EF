using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public class AirlineRepository : GenericRepository<Airline>, IAirlineRepository
    {
        public AirlineRepository(DataContext dataContext, ISortHelper<Airline> sortHelper)
            : base(dataContext, sortHelper) { }

        public override async Task<Guid> CreateAsync(Airline entity)
        {
            await entities.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.AirlineId;
        }
    }
}
