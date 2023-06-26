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
    public class TicketConf : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.TicketId);
            builder
                .HasOne(x => x.Flight)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.FlightId);
            builder
                .HasOne(x => x.Passenger)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.PassengerId);
            builder
                .Property(x => x.TicketPrice)
                .HasColumnType("DECIMAL(18, 2)");
        }
    }
}
