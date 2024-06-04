using FluentValidation;
using FluentValidation.AspNetCore;
using IssueTracker.Core;
using IssueTracker.Infrastructure;
using IssueTracker.Infrastructure.Postgres;
using IssueTracker.Web;
using IssueTracker.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Identity
builder.Services
    .AddPostgres<IdentityDbContext>()
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
    .AddEntityFrameworkStores<IdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    options.LoginPath = "/Accounts/Login";
    options.LogoutPath = "/Accounts/Logout";
    options.SlidingExpiration = true;
});

builder.Services.AddMvc(opts =>
{
    var authPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opts.Filters.Add(new AuthorizeFilter(authPolicy));
});

builder.Services
    .AddInfrastructure()
    .AddCore()
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