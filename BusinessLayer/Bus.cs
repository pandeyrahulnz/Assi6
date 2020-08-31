using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus_Route_Allocation_Core_Web_App.BusinessLayer
{
    
    //Bus details
    public class Bus
    {
        //Bus id
        public int Id { get; set; }

        //Bus number
        public string BusNumber { get; set; }

        //Transport company name
        public string TransportCompany { get; set;  }



    }
}
