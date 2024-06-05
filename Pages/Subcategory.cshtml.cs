using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class SubcategoryModel : PageModel
    {
        private readonly Data.SnackistwoContext _context;

        public SubcategoryModel(Data.SnackistwoContext context)
        {
            _context = context;
        }

        public Subcategory Subcategory { get; set; }
        public List<Topic> Topics { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subcategory = await _context.Subcategory.FirstOrDefaultAsync(m => m.Id == id);

            if (Subcategory == null)
            {
                return NotFound();
            }

            Topics = await _context.Topic
                .Where(t => t.SubCategoryId == id)
                .ToListAsync();


            return Page();
        }
    }
}
