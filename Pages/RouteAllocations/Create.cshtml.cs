using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.RouteAllocations
{
    //Create a route allocation
    public class CreateModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public CreateModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets the create route allocation form.
        public IActionResult OnGet()
        {
        ViewData["BusId"] = new SelectList(_context.Bus, "Id", "BusNumber");
        ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "Name");
        ViewData["RouteId"] = new SelectList(_context.Set<Route>(), "Id", "Name");
            return Page();
        }

        //Binds the route model.
        [BindProperty]
        public RouteAllocation RouteAllocation { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds the route allocation to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RouteAllocation.Add(RouteAllocation);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
