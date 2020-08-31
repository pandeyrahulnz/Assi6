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
    //Deletes the route allocation.
    public class DeleteModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DeleteModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the route allocation model.
        [BindProperty]
        public RouteAllocation RouteAllocation { get; set; }

        //Gets the route allocation for delete using a lamda query.
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

        //Deletes a route allocation uses  a linq query to get the route allocation.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RouteAllocation = (from routeAllocation in _context.RouteAllocation
                               where routeAllocation.Id == id
                               select routeAllocation).FirstOrDefault();

            if (RouteAllocation != null)
            {
                _context.RouteAllocation.Remove(RouteAllocation);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
