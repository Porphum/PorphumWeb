using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage;
using PorphumSales.Logic.Storage;
using PorphumWeb.Blazor;
using PorphumWeb.Logic.Models;
using PorphumWeb.Logic.Storage;
using PorphumWeb.Logic.Storage.Repository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();*/

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();

builder.Services.AddDbContext<WebContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("WebConnectionString").Value));
builder.Services.AddDbContext<ReferenceBookContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("RefBookConnectionString").Value));

// ToDo transfer logic from program cs some where else
//  maybe use context factory idk
//var salesConnectionCookie = "SalesContext-Connection";
var salesConnectionDBName = "{db_name}";

builder.Services.AddDbContext<SalesContext>((serviceProvider, optionBuilder) =>
{
    var connectionString = builder.Configuration.GetSection("SalesConnectionString").Value;

    var defaultDbName = "porphum_sales";

    optionBuilder.UseNpgsql(connectionString.Replace(salesConnectionDBName, defaultDbName));
});

builder.Services.AddReferenceBookServices(builder.Configuration);
builder.Services.AddSalesServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
