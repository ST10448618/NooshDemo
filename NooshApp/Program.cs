using NooshApp.Data;
using Microsoft.EntityFrameworkCore;
using NooshApp.Repositories;
using NooshApp.Repositories.Interfaces;
using NooshApp.Services;
using NooshApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<ICustomizeService, CustomizeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ICateringRepository, CateringRepository>();
builder.Services.AddScoped<ICateringService, CateringService>();

builder.Services.AddDistributedMemoryCache(); // required backing store for Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2); // auto-logout after 2 hrs of inactivity
    options.Cookie.HttpOnly = true;               // JS can't read the session cookie (security)
    options.Cookie.IsEssential = true;             // required for GDPR-style cookie consent rules
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // applies any pending migrations automatically
    DbSeeder.Seed(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
