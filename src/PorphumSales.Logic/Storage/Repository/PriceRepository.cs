using General.Models.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Extensions;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository;

public class PriceRepository : BaseQueryRepository<PriceableProduct, ProductPrice>, IPriceRepository
{
    private readonly IRepositoryContext _repositoryContext;
    private readonly IReferenceBookMapper _referenceBookMapper;

    public PriceRepository(IRepositoryContext repositoryContext, IReferenceBookMapper mapper)
    {
        _referenceBookMapper = mapper ?? throw new ArgumentNullException();
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException();
    }

    public void AddNewPrice(PriceableProduct price)
    {
        ArgumentNullException.ThrowIfNull(price);

        if (price.Product.MapState != General.MapState.Success)
        {
            throw new InvalidOperationException();
        }

        var storage = price.ConvertToStorage();

        _repositoryContext.ProductsPrices.Add(storage);
        _repositoryContext.SaveChanges();
    }

    public void DeletePrice(PriceableProduct price)
    {
        ArgumentNullException.ThrowIfNull(price);

        if (price.Product.MapState != General.MapState.Success)
        {
            throw new InvalidOperationException();
        }

        var storage = price.ConvertToStorage();
        var current = _repositoryContext.ProductsPrices
            .SingleOrDefault(x => x.ProductId == storage.ProductId && x.Price == storage.Price && x.FromDate == x.FromDate);

        if (current is null)
        {
            throw new InvalidOperationException();
        }

        _repositoryContext.ProductsPrices.Remove(current);
        _repositoryContext.SaveChanges();
    }

    public PriceableProduct? GetPrice(Product product, DateTime? onDate)
    {
        var date = onDate ?? DateTime.Now;
        var price = _repositoryContext.ProductsPrices
            .OrderByDescending(x => x.FromDate)
            .FirstOrDefault(x => x.ProductId == product.Key && x.FromDate <= date);

        if (price is null)
        {
            return null;
        }

        return ConvertFromStorage(price);
    }
    protected override PriceableProduct ConvertFromStorage(ProductPrice storage) => storage.ConvertToModel(_referenceBookMapper);

    protected override IQueryable<ProductPrice> GetInitQuery() => _repositoryContext.ProductsPrices
        .AsNoTracking()
        .OrderByDescending(x => x.FromDate)
        .AsQueryable();
}
