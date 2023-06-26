using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Passengers")]
    public class Passenger
    {
        [Key]
        public Guid PassengerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = default!;
        public ICollection<FlightPassenger> FlightPassengers { get; set; } = default!;
    }
}
