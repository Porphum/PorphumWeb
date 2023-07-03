using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Repository;

public sealed class ClientRepository : IClientRepository
{
    public Task AddAsync(Client entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ContainsAsync(Client entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Client entity)
    {
        throw new NotImplementedException();
    }

    public Client? GetByKey(long key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Client> GetEntities()
    {
        throw new NotImplementedException();
    }

    public Client? GetPartialByKey(long key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Client> GetPartialEntities()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
