using General;
using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Storage.Repository;
/// <summary xml:lang="ru">
/// Репозиторий продуктов и их групп.
/// </summary>
public sealed class ProductRepository : IProductRepository
{
    private IRepositoryContext _repositoryContext;

    /// <summary xml:lang = "ru">
    /// Создаёт экземпляр класса <see cref="ProductRepository"/>.
    /// </summary>
    /// <param name="repositoryContext" xml:lang = "ru">Контекст репозитория.</param>
    /// <exception cref="ArgumentNullException" xml:lang = "ru">
    /// Если один из параметров равен <see langword="null"/>.
    /// </exception>
    public ProductRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    private Product? GetWithModByKey(long key, bool isFullLoad)
    {
        var products = _repositoryContext.Products
            .AsNoTrackingWithIdentityResolution()
            .Include(x => x.Group)
            .AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.Info);
        }

        var find = products.SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel(isFullLoad);
    }

    private IEnumerable<Product> GetWithModEntities(bool isFullLoad)
    {
        var products = _repositoryContext.Products
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.Info);
        }

        return products
            .Include(x => x.Group)
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad));
    }

    /// <inheritdoc/>
    public Product? GetByKey(long key) => GetWithModByKey(key, true);

    /// <inheritdoc/>
    public IEnumerable<Product> GetEntities() => GetWithModEntities(true);

    /// <inheritdoc/>
    public async Task<bool> ContainsAsync(Product entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Products
            .AsNoTracking()
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Add(Product entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = entity.ConvertToStorage();

        var group = _repositoryContext.ProductGroups.SingleOrDefault(x => x.Id == storage.GroupId) ?? throw new InvalidOperationException();

        storage.Group = group;

        _repositoryContext.Products.Add(storage);

        Save();
    }

    /// <inheritdoc/>
    public void Delete(Product entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = _repositoryContext.Products.SingleOrDefault(x => x.Id == entity.Key) ?? throw new InvalidOperationException();

        _repositoryContext.Products.Remove(storage);

        Save();
    }

    /// <inheritdoc/>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    /// <inheritdoc/>
    IEnumerable<ProductGroup> IRepository<ProductGroup>.GetEntities()
    {
        return _repositoryContext.ProductGroups
            .AsNoTracking()
            .AsEnumerable()
            .Select(p => p.ConvertToModel());
    }

    /// <inheritdoc/>
    public async Task<bool> ContainsAsync(ProductGroup entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.ProductGroups
            .AsNoTracking()
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Add(ProductGroup entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = entity.ConvertToStorage();

        _repositoryContext.ProductGroups.Add(storage);

        Save();
    }

    /// <inheritdoc/>
    public void Delete(ProductGroup entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = _repositoryContext.ProductGroups.SingleOrDefault(x => x.Id == entity.Key) ?? throw new InvalidOperationException();

        _repositoryContext.ProductGroups.Remove(storage);

        Save();
    }

    /// <inheritdoc/>
    public Product? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };

    /// <inheritdoc/>
    public IEnumerable<Product> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };

    /// <inheritdoc/>
    public ProductGroup? GetByKey(int key)
    {
        var find = _repositoryContext.ProductGroups
            .AsNoTracking()
            .SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel();
    }

    /// <inheritdoc/>
    public void Update(Product entity)
    {
        var current = _repositoryContext.Products
            .Include(x => x.Info)
            .Include(x => x.Group)
            .AsNoTracking()
            .SingleOrDefault(x => x.Id == entity.Key);

        if (current is null)
        {
            throw new ArgumentException();
        }

        var storage = entity.ConvertToStorage();
        var group = _repositoryContext.ProductGroups.AsNoTracking().SingleOrDefault(x => x.Id == storage.GroupId) ?? throw new InvalidOperationException();
        current.Group = group;
        current.Name = storage.Name;
        current.GroupId = storage.GroupId;
        storage.Info.ProductId = current.Id;
        current.Info = storage.Info;

        _repositoryContext.Products.Update(current);

        Save();
    }

    /// <inheritdoc/>
    public void Update(ProductGroup entity)
    {

        var current = _repositoryContext.ProductGroups
            .AsNoTracking()
            .SingleOrDefault(x => x.Id == entity.Key);

        if (current is null)
        {
            throw new ArgumentException();
        }

        var storage = entity.ConvertToStorage();

        current.Name = storage.Name;
        current.ParentId = storage.ParentId;

        _repositoryContext.ProductGroups.Update(current);

        Save();
    }

    public IReadOnlyCollection<ProductGroup> GetSubGroups(int? parentGroup) => _repositoryContext.ProductGroups
            .AsNoTracking()
            .Where(x => x.ParentId == parentGroup)
            .ToList()
            .Select(x => x.ConvertToModel())
            .ToList();
}
