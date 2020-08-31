using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.RouteAllocations
{
    //Gets all route allocations 
    public class IndexModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public IndexModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Routes allocation list
        public IList<RouteAllocation> RouteAllocation { get;set; }

        //Gets all route allocations using a lamda query.
        public void OnGet()
        {
            RouteAllocation = _context.RouteAllocation
                .Include(r => r.Bus)
                .Include(r => r.Driver)
                .Include(r => r.Route).ToList();
        }
    }
}
