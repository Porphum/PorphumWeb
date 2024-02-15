using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage.Repository.Query.Params;

public class OfProductIdHistoreisRroductParam : IQueryParam<ProductCountHistory>
{
    private readonly long _productId;

    public OfProductIdHistoreisRroductParam(long productId)
    {
        _productId = productId;
    }

    public IQueryable<ProductCountHistory> ApplyParam(IQueryable<ProductCountHistory> data) => data.Where(x => x.ProductId == _productId).AsQueryable();
}
