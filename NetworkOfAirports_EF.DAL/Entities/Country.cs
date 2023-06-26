using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Entitites
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CountryName { get; set; } = string.Empty;
        public ICollection<City> Cities { get; set; } = default!;
    }
}
