﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mot_Denis_Lab_2.Data;
using Mot_Denis_Lab_2.Models;

namespace Mot_Denis_Lab_2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context _context;

        public DetailsModel(Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing
                 .Include(b => b.Member)
                 .Include(b => b.Book.Author)
                    .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }

            
            return Page();
        }
    }
}
