using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Snackistwo.Pages
{
    public class ReportedMessagesModel : PageModel
    {
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;
        private readonly Data.SnackistwoContext _context;

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }

        public ReportedMessagesModel(UserManager<Areas.Identity.Data.SnackistwoUser> userManager, RoleManager<IdentityRole> roleManager, Data.SnackistwoContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Models.Reply> Reports { get; set; } = new List<Models.Reply>();

        public async Task<IActionResult> OnGetAsync()
        {
            Reports = await _context.Reply.Where(r => r.IsReported == true).ToListAsync();

            return Page();
        }
    }
}
