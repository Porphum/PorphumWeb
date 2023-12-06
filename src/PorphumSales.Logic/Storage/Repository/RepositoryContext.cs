using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository;

public sealed class RepositoryContext : IRepositoryContext
{
    private readonly SalesContext _salesContext;

    public RepositoryContext(SalesContext salesContext)
    {
        _salesContext = salesContext ?? throw new ArgumentNullException(nameof(salesContext));
    }

    /// <inheritdoc/>
    public DbSet<DocumentsRow> DocumentsRows => _salesContext.DocumentsRows;

    /// <inheritdoc/>
    public DbSet<Document> Documents => _salesContext.Documents;

    /// <inheritdoc/>
    public DbSet<DocumentConfig> Configs => _salesContext.DocumentConfigs;

    public DbSet<ProductCountHistory> ProductsCountHistories => _salesContext.ProductsCountHistories;

    public DbSet<ProductPrice> ProductsPrices => _salesContext.ProductsPrices;

    public DbSet<ProductStorage> ProductsStorages => _salesContext.ProductsStorages;

    /// <inheritdoc/>
    public void SaveChanges() => _salesContext.SaveChanges();
}
