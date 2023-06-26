using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAirlineRepository Airlines { get; }
        IAirportRepository Airports { get; }
        IFlightPassengerRepository FlightPassengers { get; }
        IFlightRepository Flights { get; }

        Task SaveChangesAsync();
    }
}
