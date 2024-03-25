using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FairwayManager.Models;

namespace FairwayManager.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly FairwayManager.Models.FairwayManagerDBContext _context;

        public IndexModel(FairwayManager.Models.FairwayManagerDBContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Members != null)
            {
                Member = await _context.Members.ToListAsync();
            }
        }
    }
}
