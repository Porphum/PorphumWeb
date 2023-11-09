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
    public async Task AddAsync(Client entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.Clients
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Delete(Client entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.Clients.AsNoTracking().SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exist in context");
        }

        _repositoryContext.Clients.Remove(storage);
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
}
