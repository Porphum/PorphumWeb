using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;
public interface IPriceRepository : IQueryableRepository<PriceableProduct, ProductPrice>
{
    public void AddNewPrice(PriceableProduct price);

    public void DeletePrice(PriceableProduct price);
}
