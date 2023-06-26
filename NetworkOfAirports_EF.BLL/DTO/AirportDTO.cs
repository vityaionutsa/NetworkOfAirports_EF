using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class AirportDTO
    {
        public string AirportCode { get; set; } = string.Empty;
        public string AirportName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
    }
}
