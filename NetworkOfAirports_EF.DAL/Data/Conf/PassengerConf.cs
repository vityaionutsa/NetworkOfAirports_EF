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
    public class PassengerConf : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(x => x.PassengerId);
            builder
                .HasMany(x => x.Tickets)
                .WithOne(x => x.Passenger)
                .HasForeignKey(x => x.PassengerId);
            builder
                .HasMany(x => x.FlightPassengers)
                .WithOne(x => x.Passenger)
                .HasForeignKey(x => x.PassengerId);
        }
    }
}
