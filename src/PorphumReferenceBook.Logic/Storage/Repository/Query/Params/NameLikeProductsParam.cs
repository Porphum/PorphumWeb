using General.Abstractions.Storage.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query.Params;

public sealed class NameLikeProductsParam : IQueryParam<Product>
{
    private readonly string _name;
    public NameLikeProductsParam(string name)
    {
        _name = name;
    }

    public IQueryable<Product> ApplyParam(IQueryable<Product> data) => data.Where(c => EF.Functions.Like(c.Name, $"%{_name}%")).AsQueryable();
}
