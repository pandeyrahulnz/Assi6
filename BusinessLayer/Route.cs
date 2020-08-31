using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus_Route_Allocation_Core_Web_App.BusinessLayer
{
    //Bus  route
    public class Route
    {
        //Bus route Id
        public int Id { get; set; }

        //Bus route name
        public string Name { get; set;  }

        //route  distance in Km
        public int RouteDistance { get; set;  }

    }
}
