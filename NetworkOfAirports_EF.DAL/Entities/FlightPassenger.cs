using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("FlightPassengers")]
    public class FlightPassenger
    {
        [Key]
        public Guid FlightPassengerId { get; set; }
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public Flight Flight { get; set; } = default!;
        public Passenger Passenger { get; set; } = default!;
    }
}
