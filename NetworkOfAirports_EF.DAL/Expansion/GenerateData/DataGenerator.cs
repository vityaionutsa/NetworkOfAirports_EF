using Bogus;
using NetworkOfAirports_EF.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Expansion.GenerateData
{
    public static class DataGenerator
    {
        private const int AIRLINES = 150;
        private const int AIRPORTS = 150;
        private const int CITIES = 150;
        private const int COUNTRIES = 150;
        private const int FLIGHTS = 150;
        private const int FLIGHT_PASSENGERS = 150;
        private const int PASSENGERS = 150;
        private const int TICKETS = 150;

        public static List<Airline> Airlines { get; set; } = new();
        public static List<Airport> Airports { get; set; } = new();
        public static List<City> Cities { get; set; } = new();
        public static List<Country> Countries { get; set; } = new();
        public static List<Flight> Flights { get; set; } = new();
        public static List<FlightPassenger> FlightPassengers { get; set; } = new();
        public static List<Passenger> Passengers { get; set; } = new();
        public static List<Ticket> Tickets { get; set; } = new();
        public static void Generate()
        {
            Countries = new Faker<Country>()
                .RuleFor(x => x.CountryId, _ => Guid.NewGuid())
                .RuleFor(x => x.CountryName, f =>
                {
                    var country = f.Address.Country();
                    return country.Length <= 50 ? country : country.Substring(0, 50);
                })
                .Generate(COUNTRIES);
            Cities = new Faker<City>()
                .RuleFor(x => x.CityId, _ => Guid.NewGuid())
                .RuleFor(x => x.CityName, f => f.Address.City())
                .RuleFor(x => x.CountryId, f => f.PickRandom(Countries).CountryId)
                .Generate(CITIES);
            Airports = new Faker<Airport>()
                .RuleFor(x => x.AirportId, _ => Guid.NewGuid())
                .RuleFor(x => x.AirportCode, _ => $"{new Random().Next(10000):D4}-{new Random().Next(10000):D4}-{new Random().Next(10000):D4}")
                .RuleFor(x => x.AirportName, f => f.Lorem.Sentence(6).TrimEnd('.'))
                .RuleFor(x => x.CityId, f => f.PickRandom(Cities).CityId)
                .Generate(AIRPORTS);
            Airlines = new Faker<Airline>()
                .RuleFor(x => x.AirlineId, _ => Guid.NewGuid())
                .RuleFor(x => x.AirlineName, f => f.Lorem.Sentence(5).TrimEnd('.'))
                .Generate(AIRLINES);
            Flights = new Faker<Flight>()
                .RuleFor(x => x.FlightId, _ => Guid.NewGuid())
                .RuleFor(x => x.AirlineId, f => f.PickRandom(Airlines).AirlineId)
                .RuleFor(x => x.DepartureAirportId, f => f.PickRandom(Airports).AirportId)
                .RuleFor(x => x.ArrivalAirportId, f => f.PickRandom(Airports).AirportId)
                .RuleFor(x => x.DepartureDate, f => f.Date.Past(10))
                .RuleFor(x => x.ArrivalDate, (f, x) => f.Date.Past(x.DepartureDate.Year, x.DepartureDate.AddYears(1)))
                .Generate(FLIGHTS);
            Passengers = new Faker<Passenger>()
                .RuleFor(x => x.PassengerId, _ => Guid.NewGuid())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .Generate(PASSENGERS);
            Tickets = new Faker<Ticket>()
                .RuleFor(x => x.TicketId, _ => Guid.NewGuid())
                .RuleFor(x => x.FlightId, f => f.PickRandom(Flights).FlightId)
                .RuleFor(x => x.PassengerId, f => f.PickRandom(Passengers).PassengerId)
                .RuleFor(x => x.SeatNumber, f => f.Random.Int(0, 300))
                .RuleFor(x => x.TicketPrice, f => f.Random.Decimal(0, 10000))
                .Generate(TICKETS);

            FlightPassengers = new Faker<FlightPassenger>()
                .RuleFor(x => x.FlightPassengerId, _ => Guid.NewGuid())
                .RuleFor(x => x.PassengerId, f => f.PickRandom(Passengers).PassengerId)
                .RuleFor(x => x.FlightId, f => f.PickRandom(Flights).FlightId)
                .Generate(FLIGHT_PASSENGERS);
        }
    }
}
