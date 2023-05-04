using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_Dotnet_.Areas.Identity.Data;
using Projet_Dotnet_.Models;

namespace Projet_Dotnet_.Data;

public class Projet_Dotnet_DbContext : IdentityDbContext<User>
{
    public Projet_Dotnet_DbContext(DbContextOptions<Projet_Dotnet_DbContext> options)
        : base(options)
    {

    }
    public DbSet<Transaction> transactions { get; set; }

    public DbSet<Category> categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
