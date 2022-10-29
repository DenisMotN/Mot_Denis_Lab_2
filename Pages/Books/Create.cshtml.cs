using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mot_Denis_Lab_2.Data;
using Mot_Denis_Lab_2.Models;

namespace Mot_Denis_Lab_2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context _context;

        public CreateModel(Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorName"] = new SelectList(_context.Set<Author>(), "ID", "FirstName", "LastName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
