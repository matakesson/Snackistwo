using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Snackistwo.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;
        private readonly Data.SnackistwoContext _context;

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }

        public MessagesModel(UserManager<Areas.Identity.Data.SnackistwoUser> userManager, RoleManager<IdentityRole> roleManager, Data.SnackistwoContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Models.Message Message { get; set; }
        public List<Models.Message> Messages { get; set; }

        [BindProperty]
        public Models.Message NewMessage { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);

            if (MyUser != null)
            {
                Messages = await _context.Message
                    .Where(m => m.RecipientId == MyUser.Id)
                    .OrderByDescending(m => m.SentOn)
                    .ToListAsync();
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);

            if (MyUser != null && !string.IsNullOrEmpty(NewMessage.RecipientName))
            {
                var recipient = await _userManager.FindByEmailAsync(NewMessage.RecipientName);
                if (recipient == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return Page();
                }

                var message = new Models.Message
                {
                    SenderId = MyUser.Id,
                    SenderName = MyUser.UserName,
                    RecipientId = recipient.Id,
                    RecipientName = recipient.UserName,
                    Title = NewMessage.Title,
                    Content = NewMessage.Content,
                    SentOn = DateTime.UtcNow
                };

                _context.Message.Add(message);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Messages");
            }

            return Page();
        }
    }
}
