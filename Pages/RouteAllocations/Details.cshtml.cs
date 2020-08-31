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
    //Gets the Details of the route allocation 
    public class DetailsModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DetailsModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Holds the route allocation.
        public RouteAllocation RouteAllocation { get; set; }

        //Gets the route allocation details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RouteAllocation =  _context.RouteAllocation
                .Include(r => r.Bus)
                .Include(r => r.Driver)
                .Include(r => r.Route).FirstOrDefault(m => m.Id == id);

            if (RouteAllocation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
