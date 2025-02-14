using Microsoft.EntityFrameworkCore;
using Mission06_Serre.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This enables MVC (Model-View-Controller) support for handling web requests.
builder.Services.AddControllersWithViews();

// Configure the database context to use SQLite.
// The connection string is retrieved from appsettings.json.
builder.Services.AddDbContext<MovieCollectionContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline (middleware processing).
if (!app.Environment.IsDevelopment())
{
    // In production, use an error handler to show user-friendly error pages.
    app.UseExceptionHandler("/Home/Error");

    // Enforce HTTPS and add HTTP Strict Transport Security (HSTS) for security.
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enable serving static files (CSS, JS, images, etc.).
app.UseStaticFiles();

// Enable request routing to match URLs to controllers and actions.
app.UseRouting();

// Enable authorization (currently not configured for authentication).
app.UseAuthorization();

// Define the default route pattern for the application.
// Requests will be routed to HomeController's Index action by default.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the application.
app.Run();