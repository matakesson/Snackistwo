using Microsoft.AspNetCore.Identity;

namespace Snackistwo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SnackistwoUser class
public class SnackistwoUser : IdentityUser
{
    public string Image { get; set; } = "20240527153630.jpg";
}

