using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.ItemChefs
{
    public class CreateModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public CreateModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ChefId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ItemChef ItemChef { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ItemChefs == null || ItemChef == null)
            {
                return Page();
            }

            _context.ItemChefs.Add(ItemChef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
