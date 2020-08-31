using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bus_Route_Allocation_Core_Web_App.BusinessLayer;
using Bus_Route_Allocation_Core_Web_App.Models;

namespace Bus_Route_Allocation_Core_Web_App.Pages.Drivers
{
    //Deletes a Driver.
    public class DeleteModel : PageModel
    {
        private readonly Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext _context;

        public DeleteModel(Bus_Route_Allocation_Core_Web_App.Models.ASSI6Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds driver model.
        [BindProperty]
        public Driver Driver { get; set; }

        //Gets a driver for delete using  a lamda  query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver =  _context.Driver.FirstOrDefault(m => m.Id == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the driver uses a linq query to delete the driver.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = (from driver in _context.Driver
                      where driver.Id == id
                      select driver).FirstOrDefault();

            if (Driver != null)
            {
                _context.Driver.Remove(Driver);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
