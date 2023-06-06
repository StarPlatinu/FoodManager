using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.ItemChefs
{
    public class DeleteModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public DeleteModel(Restaurant_Management.Models.RestaurantDbContext context)
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

            var itemchef = await _context.ItemChefs.FirstOrDefaultAsync(m => m.Id == id);

            if (itemchef == null)
            {
                return NotFound();
            }
            else 
            {
                ItemChef = itemchef;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.ItemChefs == null)
            {
                return NotFound();
            }
            var itemchef = await _context.ItemChefs.FindAsync(id);

            if (itemchef != null)
            {
                ItemChef = itemchef;
                _context.ItemChefs.Remove(ItemChef);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
