using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.Routes
{
    //Deletes the route.
    public class DeleteModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DeleteModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the route model.

        [BindProperty]
        public Route Route { get; set; }

        //Gets the route for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = _context.Route.FirstOrDefault(m => m.Id == id);

            if (Route == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the route . uses a linq query to select.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = (from route in _context.Route
                     where route.Id == id
                     select route).FirstOrDefault();

            if (Route != null)
            {
                _context.Route.Remove(Route);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
