using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class ReplyModel : PageModel
    {
        private readonly Data.SnackistwoContext _context;
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;

        public ReplyModel(Data.SnackistwoContext context, UserManager<Areas.Identity.Data.SnackistwoUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }
        public Topic Topic { get; set; }

        [BindProperty]
        public Reply Reply { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            MyUser = await _userManager.GetUserAsync(User);
            Topic = await _context.Topic.FirstOrDefaultAsync(t => t.Id == id);
            Reply = new Reply { TopicId = id };

            Reply.TopicId = id;
            if (MyUser != null)
            {
                Reply.UserId = MyUser.Id;
                Reply.UserName = MyUser.UserName;
            }
            Reply.PostedOn = DateTime.Now;


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MyUser = await _userManager.GetUserAsync(User);
            if (MyUser != null)
            {
                Reply.UserId = MyUser.Id;
                Reply.UserName = MyUser.UserName;
            }

            _context.Reply.Add(Reply);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
