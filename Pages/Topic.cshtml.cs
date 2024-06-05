using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class TopicModel : PageModel
    {
        private readonly Data.SnackistwoContext _context;
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;

        public TopicModel(UserManager<Areas.Identity.Data.SnackistwoUser> userManager, Data.SnackistwoContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Topic Topic { get; set; }
        public string TopicUserName { get; set; }
        public string TopicUserImage { get; set; }
        public Dictionary<Reply, string> Replies { get; set; } = new Dictionary<Reply, string>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Topic = await _context.Topic.FirstOrDefaultAsync(t => t.Id == id);

            var user = await _userManager.FindByIdAsync(Topic.UserId);
            if (user != null)
            {
                TopicUserName = user.UserName;
                TopicUserImage = user.Image;
            }

            if (Topic == null)
            {
                return NotFound();
            }

            var replies = await _context.Reply.Where(r => r.TopicId == id).ToListAsync();

            foreach (var reply in replies)
            {
                var replyUser = await _userManager.FindByIdAsync(reply.UserId);
                if (replyUser != null)
                {
                    Replies[reply] = replyUser.Image;
                }
            }

            return Page();
        }
    }
}
