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
    public class AirportConf : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(x => x.AirportId);
            builder
                .HasOne(x => x.City)
                .WithMany(x => x.Airports)
                .HasForeignKey(x => x.CityId);
            builder
                .HasMany(x => x.DepartureFlights)
                .WithOne(x => x.DepartureAirport)
                .HasForeignKey(x => x.DepartureAirportId);
            builder
                .HasMany(x => x.ArrivalFlights)
                .WithOne(x => x.ArrivalAirport)
                .HasForeignKey(x => x.ArrivalAirportId);
        }
    }
}
