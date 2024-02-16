using General.Abstractions.Storage.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query.Params;
public sealed class NameLikeClientsParam : IQueryParam<Client>
{
    private readonly string _name;
    public NameLikeClientsParam(string name)
    {
        _name = name;
    }

    public IQueryable<Client> ApplyParam(IQueryable<Client> data) => data.Where(c => EF.Functions.Like(c.Name, $"%{_name}%")).AsQueryable();
}
