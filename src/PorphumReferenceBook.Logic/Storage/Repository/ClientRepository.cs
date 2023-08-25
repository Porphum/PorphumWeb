using General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    private Client? GetWithModByKey(long key, bool isFullLoad)
    {
        var clients = _repositoryContext.Clients.AsQueryable();

        if (isFullLoad)
        {
            clients = clients.Include(x => x.Info);
        }

        var find = clients.SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel(isFullLoad);
    }

    private IEnumerable<Client> GetWithModEntities(bool isFullLoad)
    {
        var clients = _repositoryContext.Clients.AsQueryable();

        if (isFullLoad)
        {
            clients = clients.Include(x => x.Info);
        }

        return clients
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad));
    }

    public Client? GetByKey(long key) => GetWithModByKey(key, true);

    public IEnumerable<Client> GetEntities() => GetWithModEntities(true);

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

    public Client? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };


    public IEnumerable<Client> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };
}
