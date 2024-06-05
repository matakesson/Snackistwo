using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackistwo.Data;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class ReportModel : PageModel
    {
        private readonly SnackistwoContext _context;
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;

        public ReportModel(SnackistwoContext context, UserManager<Areas.Identity.Data.SnackistwoUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Reply Reply { get; set; }

        [BindProperty]
        public string ReportMessage { get; set; }

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            MyUser = await _userManager.GetUserAsync(User);

            Reply = await _context.Reply.FindAsync(id);

            if (Reply == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Reply = await _context.Reply.FindAsync(id);

            var username = Reply.UserName;

            if (Reply == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Reply.IsReported = true;
            Reply.ReportMessage = ReportMessage;

            // Update the entity in the database
            _context.Update(Reply);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Topic", new { id = Reply.TopicId });
        }
    }
}
