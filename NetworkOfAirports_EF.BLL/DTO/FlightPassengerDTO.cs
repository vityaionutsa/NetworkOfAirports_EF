using NetworkOfAirports_EF.DAL.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class FlightPassengerDTO
    {
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public DateTime FlightDepartureDate { get; set; }
        public DateTime FlightArrivalDate { get; set; }
        public string PassengerFirstName { get; set; } = string.Empty;
        public string PassengerLastName { get; set; } = string.Empty;
    }
}
