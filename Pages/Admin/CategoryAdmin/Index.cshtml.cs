using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages.Admin.CategoryAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Snackistwo.Data.SnackistwoContext _context;

        public IndexModel(Snackistwo.Data.SnackistwoContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
