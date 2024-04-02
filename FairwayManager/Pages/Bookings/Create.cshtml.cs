using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FairwayManager.Models;

namespace FairwayManager.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly FairwayManager.Models.FairwayManagerDBContext _context;

        public CreateModel(FairwayManager.Models.FairwayManagerDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerFourMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
        ViewData["PlayerOneMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
        ViewData["PlayerThreeMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
        ViewData["PlayerTwoMembershipID"] = new SelectList(_context.Members, "MembershipID", "MembershipID");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
            {
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
