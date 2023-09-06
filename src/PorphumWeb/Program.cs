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
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<WebContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("WebConnectionString").Value));
builder.Services.AddDbContext<ReferenceBookContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetSection("RefBookConnectionString").Value));

// ToDo transfer logic from program cs some where else
//  maybe use context factory idk
var salesConnectionCookie = "SalesContext-Connection";
var salesConnectionDBName = "{db_name}";

builder.Services.AddDbContext<SalesContext>((serviceProvider, optionBuilder) =>
{
    var connectionString = builder.Configuration.GetSection("SalesConnectionString").Value;

    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
    
    if (httpContext is null)
    {
        throw new InvalidOperationException($"Can't access to {typeof(SalesContext)} without http context");
    }

    var connectionCookie = httpContext.Request.Cookies[salesConnectionCookie];

    if (connectionCookie is null)
    {
        throw new InvalidOperationException($"Can't access to {typeof(SalesContext)} without valid cookie {salesConnectionCookie}");
    }
    
    
    var findConnection = serviceProvider.GetRequiredService<WebContext>().Connections.FirstOrDefault(x => x.IsActive && x.KeyId == connectionCookie);

    if (findConnection is null)
    {
        throw new InvalidOperationException($"Can't find active connection by key: '{connectionCookie}' for {typeof(SalesContext)}");
    }

    optionBuilder.UseNpgsql(connectionString.Replace(salesConnectionDBName, findConnection.DbName));
});

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