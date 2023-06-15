using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodManager.Model;

namespace FoodManager.Pages.Admin.FoodTypes
{
    public class DetailsModel : PageModel
    {
        private readonly FoodManager.Model.FoodManagerDBContext _context;

        public DetailsModel(FoodManager.Model.FoodManagerDBContext context)
        {
            _context = context;
        }

      public FoodType FoodType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoodType == null)
            {
                return NotFound();
            }

            var foodtype = await _context.FoodType.FirstOrDefaultAsync(m => m.Id == id);
            if (foodtype == null)
            {
                return NotFound();
            }
            else 
            {
                FoodType = foodtype;
            }
            return Page();
        }
    }
}
