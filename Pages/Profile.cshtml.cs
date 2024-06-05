using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Snackistwo.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<Areas.Identity.Data.SnackistwoUser> _userManager;
        private readonly Data.SnackistwoContext _context;

        public Areas.Identity.Data.SnackistwoUser MyUser { get; set; }

        public ProfileModel(UserManager<Areas.Identity.Data.SnackistwoUser> userManager, RoleManager<IdentityRole> roleManager, Data.SnackistwoContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Models.Profile Profile { get; set; }
        public IFormFile UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);
            Profile = new Models.Profile();

            if (MyUser != null) // Testa ta bort
            {
                Profile.UserId = MyUser.Id;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);

            var image = UploadedImage;
            string fileName = "";

            if (image != null)
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(UploadedImage.FileName);
                string filePath = Path.Combine("wwwroot/userImages", fileName);


                using (var fileStream = new FileStream("./wwwroot/userImages/" + fileName, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                MyUser.Image = fileName;

                await _userManager.UpdateAsync(MyUser);
            }

            return RedirectToPage("/Index");
        }
    }
}
