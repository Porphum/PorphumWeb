using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PorphumWeb.Logic.Storage;

public class WebContextFactory : IDesignTimeDbContextFactory<WebContext>
{
    public WebContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebContext>();
        optionsBuilder.UseNpgsql("Host=postgres_container;Port=5432;Database=porphum_web;Username=postgres;Password=root");

        return new WebContext(optionsBuilder.Options);
    }
}