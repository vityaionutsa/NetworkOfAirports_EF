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
    public class AirlineConf : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasKey(x => x.AirlineId);
            builder
                .HasMany(x => x.Flights)
                .WithOne(x => x.Airline)
                .HasForeignKey(x => x.AirlineId);
        }
    }
}
