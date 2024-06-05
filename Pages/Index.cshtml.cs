using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Models;

namespace Snackistwo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;
        private readonly Data.SnackistwoContext _context;

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }

        public IndexModel(UserManager<Areas.Identity.Data.SnackistwoUser> userManager, RoleManager<IdentityRole> roleManager, Data.SnackistwoContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public Subcategory Subcategory { get; set; }
        public List<Subcategory> Subcategories { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await DAL.CategoryManagerAPI.GetCategories();
            Subcategories = await _context.Subcategory.ToListAsync();
            MyUser = await _userManager.GetUserAsync(User);

            return Page();
        }
    }
}
