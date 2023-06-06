using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public DetailsModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

      public Recipe Recipe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            else 
            {
                Recipe = recipe;
            }
            return Page();
        }
    }
}
