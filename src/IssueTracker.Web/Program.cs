using FluentValidation;
using FluentValidation.AspNetCore;
using IssueTracker.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Identity
builder.Services
    .AddDbContext<ApplicationDbContext>(opts =>
    {
        opts.UseSqlite(builder.Configuration.GetConnectionString("Default"));
    })
    .AddIdentity<IdentityUser, IdentityRole>(opts =>
    {
        opts.SignIn.RequireConfirmedAccount = false; // Allow user to login without email confirmation link
        opts.Password.RequireDigit = true;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireNonAlphanumeric = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequiredLength = 6;
        opts.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddMvc(opts =>
{
    var authPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opts.Filters.Add(new AuthorizeFilter(authPolicy));
});

builder.Services
    .AddValidatorsFromAssembly(typeof(Program).Assembly)
    .AddFluentValidationAutoValidation(opts => opts.DisableDataAnnotationsValidation = true)
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();