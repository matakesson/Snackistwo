using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Snackistwo.Areas.Identity.Data;
using Snackistwo.Models;

namespace Snackistwo.Data;

public class SnackistwoContext : IdentityDbContext<SnackistwoUser>
{
    public SnackistwoContext(DbContextOptions<SnackistwoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

    }

    public DbSet<Snackistwo.Models.Category> Category { get; set; } = default!;

    public DbSet<Snackistwo.Models.Subcategory> Subcategory { get; set; } = default!;

    public DbSet<Snackistwo.Models.Topic> Topic { get; set; } = default!;

    public DbSet<Snackistwo.Models.Reply> Reply { get; set; } = default!;

public DbSet<Snackistwo.Models.Message> Message { get; set; } = default!;
}
