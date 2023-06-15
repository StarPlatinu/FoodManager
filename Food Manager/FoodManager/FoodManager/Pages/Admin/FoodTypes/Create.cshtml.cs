using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodManager.Model;

namespace FoodManager.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        private readonly FoodManager.Model.FoodManagerDBContext _context;

        public CreateModel(FoodManager.Model.FoodManagerDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodType FoodType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FoodType == null || FoodType == null)
            {
                return Page();
            }

            _context.FoodType.Add(FoodType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
