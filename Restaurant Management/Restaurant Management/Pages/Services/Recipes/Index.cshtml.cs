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
    public class IndexModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public IndexModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recipes != null)
            {
                Recipe = await _context.Recipes
                .Include(r => r.Ingredient).ToListAsync();
            }
        }
    }
}
