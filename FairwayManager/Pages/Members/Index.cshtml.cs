﻿using System;
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

        public IList<Member> Member { get; set; }

        public string MembershipIDSortParm { get; set; }
        public string NameSortParm { get; set; }
        public string SexSortParm { get; set; }
        public string EmailSortParm { get; set; }
        public string HandicapSortParm { get; set; }

        public string CurrentSexFilter { get; set; }
        public string CurrentHandicapFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string sexFilter, string handicapFilter)
        {
            CurrentSexFilter = sexFilter;
            CurrentHandicapFilter = handicapFilter;

            MembershipIDSortParm = String.IsNullOrEmpty(sortOrder) ? "membership_id_desc" : "";
            NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            SexSortParm = sortOrder == "Sex" ? "sex_desc" : "Sex";
            EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";
            HandicapSortParm = sortOrder == "Handicap" ? "handicap_desc" : "Handicap";

            IQueryable<Member> memberIQ = from s in _context.Members
                                          select s;

            if (!String.IsNullOrEmpty(sexFilter))
            {
                if (Enum.TryParse(sexFilter, true, out Sex sexEnum))
                {
                    memberIQ = memberIQ.Where(m => m.Sex == sexEnum);
                }
            }

            switch (handicapFilter)
            {
                case "below10":
                    memberIQ = memberIQ.Where(m => m.Handicap < 10);
                    break;
                case "above20":
                    memberIQ = memberIQ.Where(m => m.Handicap > 20);
                    break;
                case "between11and20":
                    memberIQ = memberIQ.Where(m => m.Handicap >= 10 && m.Handicap <= 20);
                    break;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    memberIQ = memberIQ.OrderByDescending(s => s.Name);
                    break;
                case "Name":
                    memberIQ = memberIQ.OrderBy(s => s.Name);
                    break;
                case "sex_desc":
                    memberIQ = memberIQ.OrderByDescending(s => s.Sex);
                    break;
                case "Sex":
                    memberIQ = memberIQ.OrderBy(s => s.Sex);
                    break;
                case "email_desc":
                    memberIQ = memberIQ.OrderByDescending(s => s.Email);
                    break;
                case "Email":
                    memberIQ = memberIQ.OrderBy(s => s.Email);
                    break;
                case "handicap_desc":
                    memberIQ = memberIQ.OrderByDescending(s => s.Handicap);
                    break;
                case "Handicap":
                    memberIQ = memberIQ.OrderBy(s => s.Handicap);
                    break;
                case "membership_id_desc":
                    memberIQ = memberIQ.OrderByDescending(s => s.MembershipID);
                    break;
                default:
                    memberIQ = memberIQ.OrderBy(s => s.MembershipID);
                    break;
            }

            Member = await memberIQ.AsNoTracking().ToListAsync();
        }
    }
}
