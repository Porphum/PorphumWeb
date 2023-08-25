using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumWeb.Logic.Storage;

public class WebContextFactory : IDesignTimeDbContextFactory<WebContext>
{
    public WebContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=porphum_web;Username=postgres;Password=root");

        return new WebContext(optionsBuilder.Options);
    }
}