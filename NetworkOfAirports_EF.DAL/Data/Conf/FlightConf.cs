using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetworkOfAirports_EF.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Data.Conf
{
    public class FlightConf : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.FlightId);
            builder
                .HasOne(x => x.Airline)
                .WithMany(x => x.Flights)
                .HasForeignKey(x => x.AirlineId);
            builder
                .HasOne(x => x.DepartureAirport)
                .WithMany(x => x.DepartureFlights)
                .HasForeignKey(x => x.DepartureAirportId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(x => x.ArrivalAirport)
                .WithMany(x => x.ArrivalFlights)
                .HasForeignKey(x => x.ArrivalAirportId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Flight)
                .HasForeignKey(x => x.FlightId);
            builder
                .HasMany(x => x.FlightPassengers)
                .WithOne(x => x.Flight)
                .HasForeignKey(x => x.FlightId);
        }
    }
}
