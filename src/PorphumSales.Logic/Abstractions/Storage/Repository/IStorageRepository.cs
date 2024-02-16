using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;
public interface IStorageRepository : IQueryableRepository<StorageProduct, ProductStorage>, IHistoryRepository
{
    public StorageProduct? GetProductState(Product product);

    public Dictionary<long, long> GetStorageState(IReadOnlySet<long> productsId);
}
