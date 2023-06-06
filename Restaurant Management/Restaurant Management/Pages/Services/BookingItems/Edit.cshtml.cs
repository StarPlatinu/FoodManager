using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.BookingItems
{
    public class EditModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public EditModel(Restaurant_Management.Models.RestaurantDbContext context)
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

            var bookingitem =  await _context.BookingItems.FirstOrDefaultAsync(m => m.Id == id);
            if (bookingitem == null)
            {
                return NotFound();
            }
            BookingItem = bookingitem;
           ViewData["BookingId"] = new SelectList(_context.Bookings, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingItemExists(BookingItem.Id))
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

        private bool BookingItemExists(long id)
        {
          return (_context.BookingItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
