using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackistwo.Models;

namespace Snackistwo.Pages.Admin.CategoryAdmin
{

    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Snackistwo.Data.SnackistwoContext _context;

        public CreateModel(Snackistwo.Data.SnackistwoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
