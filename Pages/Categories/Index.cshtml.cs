using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Birsan_Paul_Lab2.Data;
using Birsan_Paul_Lab2.Models;

namespace Birsan_Paul_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Birsan_Paul_Lab2.Data.Birsan_Paul_Lab2Context _context;

        public IndexModel(Birsan_Paul_Lab2.Data.Birsan_Paul_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();

            CategoryData.Categories = await _context.Category
              .Include(i => i.BookCategories)
                  .ThenInclude(i => i.Book)
                      .ThenInclude(i => i.Author)
              .OrderBy(i => i.CategoryName)
              .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();

                // Extragem lista de obiecte Book din relația many-to-many
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
}
