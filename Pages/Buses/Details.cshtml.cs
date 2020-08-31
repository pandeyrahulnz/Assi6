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
    //Gets Bus details
    public class DetailsModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DetailsModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Holds the Bus info.
        public Bus Bus { get; set; }

        //Gets the bus details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bus =_context.Bus.FirstOrDefault(m => m.Id == id);

            if (Bus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
