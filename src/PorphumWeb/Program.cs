using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumSales.Logic.Storage;
using PorphumWeb.Logic.Storage;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});

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
    //app.UseHsts();
}


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();