using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.OrderItems
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
        ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OrderItems == null || OrderItem == null)
            {
                return Page();
            }

            _context.OrderItems.Add(OrderItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
