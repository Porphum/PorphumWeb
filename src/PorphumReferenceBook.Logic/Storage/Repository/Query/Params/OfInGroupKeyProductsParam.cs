using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Storage.Models;
using System.Linq;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query.Params;

public class OfInGroupKeyProductsParam : IQueryParam<Product>
{
    private readonly int[] _groupId;

    public OfInGroupKeyProductsParam(IReadOnlySet<int> groupId)
    {
        _groupId = groupId.ToArray();
    }

    public IQueryable<Product> ApplyParam(IQueryable<Product> data) => data.Where(x => _groupId.Contains(x.GroupId)).AsQueryable();
}
