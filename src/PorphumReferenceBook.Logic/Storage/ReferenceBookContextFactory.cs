using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace PorphumReferenceBook.Logic.Storage;

internal class ReferenceBookContextFactory : IDesignTimeDbContextFactory<ReferenceBookContext>
{
    public ReferenceBookContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReferenceBookContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=porphum_reference_book;Username=postgres;Password=root");

        return new ReferenceBookContext(optionsBuilder.Options);
    }
}
