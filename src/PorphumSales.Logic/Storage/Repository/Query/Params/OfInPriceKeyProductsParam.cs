using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Storage.Models;


namespace PorphumReferenceBook.Logic.Storage.Repository.Query.Params;

public class OfInPriceKeyProductsParam : IQueryParam<ProductPrice>
{
    private readonly long[] _groupId;

    public OfInPriceKeyProductsParam(IReadOnlySet<long> groupId)
    {
        _groupId = groupId.ToArray();
    }

    public IQueryable<ProductPrice> ApplyParam(IQueryable<ProductPrice> data) => data.Where(x => _groupId.Contains(x.ProductId)).AsQueryable();
}
