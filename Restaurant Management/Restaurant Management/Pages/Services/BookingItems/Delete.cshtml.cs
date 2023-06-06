using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.BookingItems
{
    public class DeleteModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public DeleteModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookingItem BookingItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.BookingItems == null)
            {
                return NotFound();
            }

            var bookingitem = await _context.BookingItems.FirstOrDefaultAsync(m => m.Id == id);

            if (bookingitem == null)
            {
                return NotFound();
            }
            else 
            {
                BookingItem = bookingitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.BookingItems == null)
            {
                return NotFound();
            }
            var bookingitem = await _context.BookingItems.FindAsync(id);

            if (bookingitem != null)
            {
                BookingItem = bookingitem;
                _context.BookingItems.Remove(BookingItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
