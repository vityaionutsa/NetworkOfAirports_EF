using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataContext dbContext,
            IAirlineRepository Airlines, IAirportRepository Airports,
            IFlightPassengerRepository FlightPassengers, IFlightRepository Flights)
        {
            this.dbContext = dbContext;
            this.Airlines = Airlines;
            this.Airports = Airports;
            this.FlightPassengers = FlightPassengers;
            this.Flights = Flights;
        }
        public IAirlineRepository Airlines { get; }
        public IAirportRepository Airports { get; }
        public IFlightPassengerRepository FlightPassengers { get; }
        public IFlightRepository Flights { get; }
        public DataContext dbContext { get; set; }
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
