using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages.Admin.ReplyAdmin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Snackistwo.Data.SnackistwoContext _context;

        public IndexModel(Snackistwo.Data.SnackistwoContext context)
        {
            _context = context;
        }

        public IList<Reply> Reply { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Reply = await _context.Reply.ToListAsync();
        }
    }
}
