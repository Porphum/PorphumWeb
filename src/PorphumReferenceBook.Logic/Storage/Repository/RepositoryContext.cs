using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Storage.Repository;

public sealed class RepositoryContext : IRepositoryContext
{
    private ReferenceBookContext _referenceBookContext;

    public RepositoryContext(ReferenceBookContext referenceBookContext)
    {
        _referenceBookContext = referenceBookContext ?? throw new ArgumentNullException(nameof(referenceBookContext));
    }

    /// <inheritdoc/>
    public DbSet<Product> Products => _referenceBookContext.Products;

    /// <inheritdoc/>
    public DbSet<Client> Clients => _referenceBookContext.Clients;

    /// <inheritdoc/>
    public DbSet<ProductGroup> ProductGroups => _referenceBookContext.ProductsGroups;

    /// <inheritdoc/>
    public void SaveChanges() => _referenceBookContext.SaveChanges();
}
