using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projet_Dotnet_.Areas.Identity.Data;
using Projet_Dotnet_.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Projet_Dotnet_DbContextConnection") ?? throw new InvalidOperationException("Connection string 'Projet_Dotnet_DbContextConnection' not found.");

builder.Services.AddDbContext<Projet_Dotnet_DbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Projet_Dotnet_DbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
