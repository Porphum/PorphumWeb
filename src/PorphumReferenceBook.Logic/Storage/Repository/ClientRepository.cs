using General;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Extensions;

namespace PorphumReferenceBook.Logic.Storage.Repository;

/// <summary xml:lang="ru">
/// Репозиторий <see cref="Client"/>.
/// </summary>
public sealed class ClientRepository : IClientRepository
{
    private readonly IRepositoryContext _repositoryContext;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ClientRepository"/>.
    /// </summary>
    /// <param name="repositoryContext" xml:lang="ru">Контекст репозитория.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если один из параметров равен <see langword="null"/>.
    /// </exception>
    public ClientRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    private Client? GetWithModByKey(long key, bool isFullLoad)
    {
        var clients = _repositoryContext.Clients
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();

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
        var clients = _repositoryContext.Clients
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();

        if (isFullLoad)
        {
            clients = clients.Include(x => x.Info);
        }

        return clients
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad));
    }

    /// <inheritdoc/>
    public Client? GetByKey(long key) => GetWithModByKey(key, true);

    /// <inheritdoc/>
    public IEnumerable<Client> GetEntities() => GetWithModEntities(true);

    /// <inheritdoc/>
    public async Task<bool> ContainsAsync(Client entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Clients
            .AsNoTracking()
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Add(Client entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = entity.ConvertToStorage();

        _repositoryContext.Clients.Add(storage);

        Save();
    }

    /// <inheritdoc/>
    public void Delete(Client entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = _repositoryContext.Clients.SingleOrDefault(x => x.Id == entity.Key);

        if (storage is null)
        {
            throw new ArgumentException("Given entity not exist in context");
        }

        _repositoryContext.Clients.Remove(storage);

        Save();
    }

    /// <inheritdoc/>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    /// <inheritdoc/>
    public Client? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };


    /// <inheritdoc/>
    public IEnumerable<Client> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };

    /// <inheritdoc/>
    public void Update(Client entity)
    {
        var current = _repositoryContext.Clients
            .Include(x => x.Info)
            .SingleOrDefault(x => x.Id == entity.Key);

        if (current is null)
        {
            throw new ArgumentException();
        }

        var storage = entity.ConvertToStorage();
        current.Name = storage.Name;
        storage.Info.ClientId = current.Id;
        current.Info = storage.Info;

        _repositoryContext.Clients.Update(current);

        Save();
    }
}
