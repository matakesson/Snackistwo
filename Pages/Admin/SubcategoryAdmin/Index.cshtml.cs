using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages.Admin.SubcategoryAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Snackistwo.Data.SnackistwoContext _context;

        public IndexModel(Snackistwo.Data.SnackistwoContext context)
        {
            _context = context;
        }

        public IList<Subcategory> Subcategory { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Subcategory = await _context.Subcategory.ToListAsync();
        }
    }
}
