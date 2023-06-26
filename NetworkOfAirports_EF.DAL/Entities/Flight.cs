using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public Guid FlightId { get; set; }
        [Required]
        public Guid AirlineId { get; set; }
        [Required]
        public Guid DepartureAirportId { get; set; }
        [Required]
        public Guid ArrivalAirportId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        public Airline Airline { get; set; } = default!;
        public Airport DepartureAirport { get; set; } = default!;
        public Airport ArrivalAirport { get; set; } = default!;
        public ICollection<Ticket> Tickets { get; set; } = default!;
        public ICollection<FlightPassenger> FlightPassengers { get; set; } = default!;
    }
}
