using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace PorphumSales.Logic.Storage;

internal class SalesContextContextFactory : IDesignTimeDbContextFactory<SalesContext>
{
    public SalesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SalesContext>();
        optionsBuilder.UseNpgsql("Host=postgres_container;Port=5432;Database=porphum_reference_book;Username=postgres;Password=root");

        return new SalesContext(optionsBuilder.Options);
    }
}
