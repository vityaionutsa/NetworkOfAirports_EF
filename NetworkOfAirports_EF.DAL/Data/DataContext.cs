using Microsoft.EntityFrameworkCore;
using NetworkOfAirports_EF.DAL.Data.Conf;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.GenerateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightPassenger> FlightPassengers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AirlineConf());
            modelBuilder.ApplyConfiguration(new AirportConf());
            modelBuilder.ApplyConfiguration(new CityConf());
            modelBuilder.ApplyConfiguration(new CountryConf());
            modelBuilder.ApplyConfiguration(new FlightConf());
            modelBuilder.ApplyConfiguration(new FlightPassengerConf());
            modelBuilder.ApplyConfiguration(new PassengerConf());
            modelBuilder.ApplyConfiguration(new TicketConf());


            DataGenerator.Generate();
            modelBuilder.Entity<Country>().HasData(DataGenerator.Countries);
            modelBuilder.Entity<City>().HasData(DataGenerator.Cities);
            modelBuilder.Entity<Airport>().HasData(DataGenerator.Airports);
            modelBuilder.Entity<Airline>().HasData(DataGenerator.Airlines);
            modelBuilder.Entity<Flight>().HasData(DataGenerator.Flights);
            modelBuilder.Entity<Passenger>().HasData(DataGenerator.Passengers);
            modelBuilder.Entity<Ticket>().HasData(DataGenerator.Tickets);
            modelBuilder.Entity<FlightPassenger>().HasData(DataGenerator.FlightPassengers);
        }
    }
}
