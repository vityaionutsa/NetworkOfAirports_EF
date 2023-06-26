using NetworkOfAirports_EF.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class FlightDTO
    {
        public Guid FlightId { get; set; }
        public string AirlineName { get; set; } = string.Empty;
        public string DepartureAirportCode { get; set; } = string.Empty;
        public string DepartureAirportName { get; set; } = string.Empty;
        public string DepartureAirportCountry { get; set; } = string.Empty;
        public string ArrivalAirportCode { get; set; } = string.Empty;
        public string ArrivalAirportName { get; set; } = string.Empty;
        public string ArrivalAirportCountry { get; set; } = string.Empty;
        public (DateTime, DateTime) DepartureAndArrivalDates { get; set; }
    }
}
