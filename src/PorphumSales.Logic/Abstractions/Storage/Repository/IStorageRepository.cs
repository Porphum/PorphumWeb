using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;
public interface IStorageRepository : IQueryableRepository<StorageProduct, ProductStorage>, IHistoryRepository
{
}
