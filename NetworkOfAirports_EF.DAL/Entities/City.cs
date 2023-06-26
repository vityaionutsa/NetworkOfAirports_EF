using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; } = string.Empty;
        [Required]
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = default!;
        public ICollection<Airport> Airports { get; set; } = default!;
    }
}
