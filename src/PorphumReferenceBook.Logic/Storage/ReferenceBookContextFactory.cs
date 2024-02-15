using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PorphumReferenceBook.Logic.Storage;

internal class ReferenceBookContextFactory : IDesignTimeDbContextFactory<ReferenceBookContext>
{
    public ReferenceBookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReferenceBookContext>();
        optionsBuilder.UseNpgsql("Host=postgres_container;Port=5432;Database=porphum_reference_book;Username=postgres;Password=root");

        return new ReferenceBookContext(optionsBuilder.Options);
    }
}
