using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus_Route_Allocation_Core_Web_App.BusinessLayer
{
    //Route allocations 
    public class RouteAllocation
    {

        //Route allocation id
        public int Id { get; set; }

        //Bus id foriegn key
        public int BusId { get; set; }

        //Driver id foriegn key
        public int DriverId { get; set; }

        //Route id forign key
        public int RouteId { get; set;  }

        //Bus reference 
        public Bus Bus { get; set; }

        //Driver reference 
        public Driver Driver { get; set; }

        //Route reference.
        public Route Route { get; set; }


    }
}
