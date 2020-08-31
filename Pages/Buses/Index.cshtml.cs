using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.Buses
{
    //Gets all buses
    public class IndexModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public IndexModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //the bus list.
        public IList<Bus> Bus { get;set; }

        //Gets all buses using a linq query
        public void OnGet()
        {
            Bus = (from bus in _context.Bus select bus).ToList();
        }
    }
}
