using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Airports")]
    public class Airport
    {
        [Key]
        public Guid AirportId { get; set; }
        [Required]
        [MaxLength(14)]
        public string AirportCode { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string AirportName { get; set; } = string.Empty;
        [Required]
        public Guid CityId { get; set; }
        public City City { get; set; } = default!;
        public ICollection<Flight> DepartureFlights { get; set; } = default!;
        public ICollection<Flight> ArrivalFlights { get; set; } = default!;
    }
}
