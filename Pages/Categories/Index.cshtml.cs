using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mot_Denis_Lab_2.Data;
using Mot_Denis_Lab_2.Models;
using Mot_Denis_Lab_2.Models.ViewModels;

namespace Mot_Denis_Lab_2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context _context;

        public IndexModel(Mot_Denis_Lab_2.Data.Mot_Denis_Lab_2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }

        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                .ThenInclude(i => i.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if(id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.BookCategories = category.BookCategories;

            }    
        }
        /*public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                Category = await _context.Category.ToListAsync();
            }
        }*/
    }
}
