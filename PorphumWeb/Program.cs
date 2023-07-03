using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumSales.Logic.Storage;
using PorphumWeb.Logic.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WebContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("WebConnectionString").Value));
builder.Services.AddDbContext<SalesContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("SalesConnectionString").Value));
builder.Services.AddDbContext<ReferenceBookContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("RefBookConnectionString").Value));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();