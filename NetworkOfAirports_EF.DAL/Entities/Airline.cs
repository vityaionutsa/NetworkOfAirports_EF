using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Airlines")]
    public class Airline
    {
        [Key]
        public Guid AirlineId { get; set; }
        [Required]
        [MaxLength(200)]
        public string AirlineName { get; set; } = string.Empty;
        public ICollection<Flight> Flights { get; set; } = default!;
    }
}
