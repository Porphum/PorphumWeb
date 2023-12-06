using General.Models.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Extensions;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository;

public class HistoryRepository : BaseQueryRepository<ProductHistory, ProductCountHistory>, IHistoryRepository
{
    private readonly IRepositoryContext _context;
    private readonly IReferenceBookMapper _referenceBookMapper;

    public HistoryRepository(IRepositoryContext context, IReferenceBookMapper referenceBookMapper)
    {
        _context = context;
        _referenceBookMapper = referenceBookMapper;
    }

    protected override IQueryable<ProductCountHistory> GetInitQuery() => _context.ProductsCountHistories.AsNoTracking().AsQueryable().OrderByDescending(x => x.AccurDate);

    protected override ProductHistory ConvertFromStorage(ProductCountHistory storage) => storage.ConvertToModel(_referenceBookMapper);

    public void ManualWrite(ProductHistory productHistory)
    {
        ArgumentNullException.ThrowIfNull(productHistory);

        if (productHistory.Product.MapState != General.MapState.Success)
        {
            throw new InvalidOperationException();
        }

        var storage = productHistory.ConvertToStorage();

        _context.ProductsCountHistories.Add(storage);

        _context.SaveChanges();
    }
}
