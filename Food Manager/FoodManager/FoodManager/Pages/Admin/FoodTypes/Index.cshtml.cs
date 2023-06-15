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
    public class IndexModel : PageModel
    {
        private readonly FoodManager.Model.FoodManagerDBContext _context;

        public IndexModel(FoodManager.Model.FoodManagerDBContext context)
        {
            _context = context;
        }

        public IList<FoodType> FoodType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FoodType != null)
            {
                FoodType = await _context.FoodType.ToListAsync();
            }
        }
    }
}
