using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }
        [Required]
        public Guid FlightId { get; set; }
        [Required]
        public Guid PassengerId { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        public Flight Flight { get; set; } = default!;
        public Passenger Passenger { get; set; } = default!;
    }
}
