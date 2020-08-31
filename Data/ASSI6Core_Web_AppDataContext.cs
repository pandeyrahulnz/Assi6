using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;

namespace Bus_Route_Allocation_Core_Web_App.Models
{
    //Connects the database and the business layer. 
    public class ASSI6Core_Web_AppDataContext : DbContext
    {
        public ASSI6Core_Web_AppDataContext (DbContextOptions<ASSI6Core_Web_AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Bus_Route_Allocation_Core_Web_App.BusinessLayer.Bus> Bus { get; set; }

        public DbSet<Bus_Route_Allocation_Core_Web_App.BusinessLayer.Driver> Driver { get; set; }

        public DbSet<Bus_Route_Allocation_Core_Web_App.BusinessLayer.RouteAllocation> RouteAllocation { get; set; }

        public DbSet<Bus_Route_Allocation_Core_Web_App.BusinessLayer.Route> Route { get; set; }
    }
}
