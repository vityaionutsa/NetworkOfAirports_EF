using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.BLL.DTO
{
    public class FlightPassengerUpdateDTO
    {
        public Guid FlightId { get; set; }
        public Guid PassengerId { get; set; }
    }
}
