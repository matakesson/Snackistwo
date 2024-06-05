using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class CreatetopicModel : PageModel
    {
        private readonly Data.SnackistwoContext _context;
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;

        public CreatetopicModel(Data.SnackistwoContext context, UserManager<Areas.Identity.Data.SnackistwoUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }
        public Subcategory Subcategory { get; set; }
        [BindProperty]
        public Topic Topic { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            MyUser = await _userManager.GetUserAsync(User);
            Subcategory = await _context.Subcategory.FirstOrDefaultAsync(s => s.Id == id);
            Topic = new Topic { SubCategoryId = id };

            if (MyUser != null)
            {
                Topic.UserId = MyUser.Id;
            }
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
                Topic.UserId = MyUser.Id;
            }

            Topic.PostedOn = DateTime.Now;
            _context.Topic.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");

        }
    }
}
