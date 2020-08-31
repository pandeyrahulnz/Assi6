using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus_Route_Allocation_Core_Web_App.BusinessLayer
{
    //Bus driver info
    public class Driver
    {
        //Bus driver id
        public int Id { get; set; }

        //Driver name 
        public string Name { get; set;  }

        //Driver phone number.
        public string PhoneNumber { get; set; }
    }
}
