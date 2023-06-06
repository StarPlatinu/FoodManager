using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.ItemChefs
{
    public class EditModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public EditModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemChef ItemChef { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.ItemChefs == null)
            {
                return NotFound();
            }

            var itemchef =  await _context.ItemChefs.FirstOrDefaultAsync(m => m.Id == id);
            if (itemchef == null)
            {
                return NotFound();
            }
            ItemChef = itemchef;
           ViewData["ChefId"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(ItemChef).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemChefExists(ItemChef.Id))
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

        private bool ItemChefExists(long id)
        {
          return (_context.ItemChefs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
