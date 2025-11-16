using System.Globalization;
using BusinessLayer.Container;
using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

var builder = WebApplication.CreateBuilder(args);


// ?? Log dosyas?n?n yolu
var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "log.txt");

builder.Services.AddScoped<GetAllDestinationQueryHandler>();

builder.Services.AddLogging(x =>
{
    x.ClearProviders();// Varsay?lan log sa?lay?c?lar?n? temizle
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();// Debug output'a loglama
});

builder.Services.AddHttpClient();


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();

builder.Services
    .AddIdentity<AppUser, AppRole>() 
    .AddEntityFrameworkStores<Context>()  
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn";          
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.LogoutPath = "/Login/Logout";
    options.SlidingExpiration = true;
});

builder.Services.ContainerDependencies();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.CustomValidation();
builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "rezervationArea",
    pattern: "{area:exists}/{controller=Rezervation}/{action=NewRezervation}/{id?}",
    defaults: new { area = "Member" }
);

app.MapControllerRoute(
    name: "destinationArea",
    pattern: "{area:exists}/{controller=Destination}/{action=Index}/{id?}",
    defaults: new { area = "Admin" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}"
);

app.Run();
