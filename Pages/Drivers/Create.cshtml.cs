using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.Drivers
{

    //Creates a driver.
    public class CreateModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public CreateModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets the driver create form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the driver property.
        [BindProperty]
        public Driver Driver { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a driver to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Driver.Add(Driver);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
