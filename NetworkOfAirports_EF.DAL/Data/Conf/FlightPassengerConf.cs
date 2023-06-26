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
    public class FlightPassengerConf : IEntityTypeConfiguration<FlightPassenger>
    {
        public void Configure(EntityTypeBuilder<FlightPassenger> builder)
        {
            builder
                .HasOne(x => x.Flight)
                .WithMany(x => x.FlightPassengers)
                .HasForeignKey(x => x.FlightId);
            builder
                .HasOne(x => x.Passenger)
                .WithMany(x => x.FlightPassengers)
                .HasForeignKey(x => x.PassengerId);
        }
    }
}
