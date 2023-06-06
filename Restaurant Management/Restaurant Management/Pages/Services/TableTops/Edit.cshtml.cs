using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.TableTops
{
    public class EditModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public EditModel(Restaurant_Management.Models.RestaurantDbContext context)
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

            var tabletop =  await _context.TableTops.FirstOrDefaultAsync(m => m.Id == id);
            if (tabletop == null)
            {
                return NotFound();
            }
            TableTop = tabletop;
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

            _context.Attach(TableTop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableTopExists(TableTop.Id))
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

        private bool TableTopExists(long id)
        {
          return (_context.TableTops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
