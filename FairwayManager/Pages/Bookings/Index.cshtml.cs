using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FairwayManager.Models;

namespace FairwayManager.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly FairwayManager.Models.FairwayManagerDBContext _context;

        public IndexModel(FairwayManager.Models.FairwayManagerDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                .Include(b => b.PlayerFour)
                .Include(b => b.PlayerOne)
                .Include(b => b.PlayerThree)
                .Include(b => b.PlayerTwo).ToListAsync();
            }
        }
    }
}
