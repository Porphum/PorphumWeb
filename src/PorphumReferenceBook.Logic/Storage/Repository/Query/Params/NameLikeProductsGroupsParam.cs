using General.Abstractions.Storage.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query.Params;

public class NameLikeProductsGroupsParam : IQueryParam<ProductGroup>
{
    private readonly string _name;
    public NameLikeProductsGroupsParam(string name)
    {
        _name = name;
    }

    public IQueryable<ProductGroup> ApplyParam(IQueryable<ProductGroup> data) => data.Where(c => EF.Functions.Like(c.Name, $"%{_name}%")).AsQueryable();
}
