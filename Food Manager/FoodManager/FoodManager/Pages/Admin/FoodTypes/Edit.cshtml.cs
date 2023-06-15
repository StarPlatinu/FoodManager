﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodManager.Model;

namespace FoodManager.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        private readonly FoodManager.Model.FoodManagerDBContext _context;

        public EditModel(FoodManager.Model.FoodManagerDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodType FoodType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoodType == null)
            {
                return NotFound();
            }

            var foodtype =  await _context.FoodType.FirstOrDefaultAsync(m => m.Id == id);
            if (foodtype == null)
            {
                return NotFound();
            }
            FoodType = foodtype;
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

            _context.Attach(FoodType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTypeExists(FoodType.Id))
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

        private bool FoodTypeExists(int id)
        {
          return (_context.FoodType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
