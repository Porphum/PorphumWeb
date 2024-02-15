using General.Abstractions.Storage.Query;
using General.Models.Query;
using Microsoft.CodeAnalysis.Operations;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Extensions;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository;
public class StorageRepository : BaseQueryRepository<StorageProduct, ProductStorage>, IStorageRepository
{
    private readonly IRepositoryContext _context;
    private readonly IHistoryRepository _historyRepository;
    private readonly IReferenceBookMapper _referenceBookMapper;

    public StorageRepository(IRepositoryContext context, IReferenceBookMapper referenceBookMapper, IHistoryRepository historyRepository)
    {
        _context = context;
        _referenceBookMapper = referenceBookMapper;
        _historyRepository = historyRepository;
    }

    protected override StorageProduct ConvertFromStorage(ProductStorage storage) => storage.ConvertToModel(_referenceBookMapper);

    protected override IQueryable<ProductStorage> GetInitQuery() => _context.ProductsStorages.AsQueryable();

    public IEnumerable<ProductHistory> GetByParams(params IQueryParam<ProductCountHistory>[] queryParams) => _historyRepository.GetByParams(queryParams);
    
    public IEnumerable<ProductHistory> GetByQuery(IQuery<IQueryParam<ProductCountHistory>, ProductCountHistory> query) => _historyRepository.GetByQuery(query);
    
    public void ManualWrite(ProductHistory productHistory) => _historyRepository.ManualWrite(productHistory);
    
    public Dictionary<long, long> GetStorageState(IReadOnlySet<long> productsId)
    {
        var state = _context.ProductsStorages
            .Where(x => x.ProductId != null)
            .Where(x => x.Sum != null)
            .Where(x => productsId.ToArray().Contains(x.ProductId!.Value));

        return state.ToDictionary(x => x.ProductId!.Value, x => x.Sum!.Value);
    }
}
