using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mot_Denis_Lab_2.Data;
using Mot_Denis_Lab_2.Models;

namespace Mot_Denis_Lab_2.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context _context;

        public DetailsModel(Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context context)
        {
            _context = context;
        }

      public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
