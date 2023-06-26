using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class FlightUpdateDTO
    {
        public Guid FlightId { get; set; }
        public Guid AirlineId { get; set; }
        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
