using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.RouteAllocations
{
    //Updates the route allocation 
    public class EditModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public EditModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the route allocation 
        [BindProperty]
        public RouteAllocation RouteAllocation { get; set; }

        //Gets the route allocation for update.
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
           ViewData["BusId"] = new SelectList(_context.Bus, "Id", "BusNumber");
           ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "Name");
           ViewData["RouteId"] = new SelectList(_context.Set<Route>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the route allocation
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RouteAllocation).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteAllocationExists(RouteAllocation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the route allocation exists using a  lamda query.
        private bool RouteAllocationExists(int id)
        {
            return _context.RouteAllocation.Any(e => e.Id == id);
        }
    }
}
