using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackistwo.Models;

namespace Snackistwo.Pages.Admin.SubcategoryAdmin
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
        public Subcategory Subcategory { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subcategory.Add(Subcategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
