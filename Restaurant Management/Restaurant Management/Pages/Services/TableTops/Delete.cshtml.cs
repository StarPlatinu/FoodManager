using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.TableTops
{
    public class DeleteModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public DeleteModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TableTop TableTop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TableTops == null)
            {
                return NotFound();
            }

            var tabletop = await _context.TableTops.FirstOrDefaultAsync(m => m.Id == id);

            if (tabletop == null)
            {
                return NotFound();
            }
            else 
            {
                TableTop = tabletop;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TableTops == null)
            {
                return NotFound();
            }
            var tabletop = await _context.TableTops.FindAsync(id);

            if (tabletop != null)
            {
                TableTop = tabletop;
                _context.TableTops.Remove(TableTop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
