using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management.Models;

namespace Restaurant_Management.Pages.Services.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Restaurant_Management.Models.RestaurantDbContext _context;

        public IndexModel(Restaurant_Management.Models.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                .Include(b => b.Table)
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
