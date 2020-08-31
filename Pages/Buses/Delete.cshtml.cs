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
    //Deletes a bus from the database.
    public class DeleteModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DeleteModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the bus model.
        [BindProperty]
        public Bus Bus { get; set; }

        //Get the bus for delete. Uses  a lamda query to select the bus.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bus =  _context.Bus.FirstOrDefault(m => m.Id == id);

            if (Bus == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the bus record from database.Uses a linq query to select the bus.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bus = (from bus in _context.Bus
                   where bus.Id == id
                   select bus).FirstOrDefault();


            if (Bus != null)
            {
                _context.Bus.Remove(Bus);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
