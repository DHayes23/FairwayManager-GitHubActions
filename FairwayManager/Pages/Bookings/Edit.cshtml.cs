using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FairwayManager.Models;

namespace FairwayManager.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly FairwayManager.Models.FairwayManagerDBContext _context;

        public EditModel(FairwayManager.Models.FairwayManagerDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
           ViewData["PlayerFourMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
           ViewData["PlayerOneMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
           ViewData["PlayerThreeMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
           ViewData["PlayerTwoMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
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

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingID))
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

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.BookingID == id)).GetValueOrDefault();
        }
    }
}
