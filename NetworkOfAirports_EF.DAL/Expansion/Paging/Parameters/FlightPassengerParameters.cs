﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfAirports_EF.DAL.Expansion.Paging.Parameters
{
    public class FlightPassengerParameters : BaseParameters
    {
        public FlightPassengerParameters()
        {
            OrderBy = "FlightId, PassengerId";
        }
    }
}
