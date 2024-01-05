//using DinkToPdf.Contracts;
//using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_of_dotnet.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<project_of_dotnetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("project_of_dotnetContext") ?? throw new InvalidOperationException("Connection string 'project_of_dotnetContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=user_data}/{action=login}/{id?}");
app.Run();
