using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;


namespace PorphumSales.Logic.Abstractions.Storage.Repository;
public interface IHistoryRepository : IQueryableRepository<ProductHistory, ProductCountHistory>
{
    public void ManualWrite(ProductHistory productHistory);
}
