using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Repository;

public sealed class ClientRepository : IClientRepository
{
    private readonly IRepositoryContext _repositoryContext;

    public ClientRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    public Client? GetByKey(long key)
    {
        var find = _repositoryContext.Clients
            .Include(x => x.Info)
            .SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel();
    }

    public IEnumerable<Client> GetEntities()
    {
        return _repositoryContext.Clients
            .Include(x => x.Info)
            .AsEnumerable()
            .Select(p => p.ConvertToModel());
    }

    public async Task<bool> ContainsAsync(Client entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Clients
            /*.AsNoTrackingWithIdentityResolution()*/
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    public async Task AddAsync(Client entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.Clients
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    public void Delete(Client entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.Products.SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.Clients.Remove(storage);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public Client? GetPartialByKey(long key)
    {
        var find = _repositoryContext.Clients
            .Include(x => x.Info)
            .SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel(isFullLoad: false);
    }

    public IEnumerable<Client> GetPartialEntities()
    {
        return _repositoryContext.Clients
            .Include(x => x.Info)
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad: false));
    }
}
