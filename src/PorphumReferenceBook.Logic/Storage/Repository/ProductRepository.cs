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
        var products = _repositoryContext.Products.
            AsNoTrackingWithIdentityResolution()
            .AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.Info);
        }

        return products
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
    public async Task AddAsync(Product entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.Products
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Delete(Product entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.Products.AsNoTracking().SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.Products.Remove(storage);
    }

    /// <inheritdoc/>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    /// <inheritdoc/>
    IEnumerable<ProductGroup> IRepository<ProductGroup>.GetEntities()
    {
        return _repositoryContext.ProductGroups.AsNoTracking()
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
    public async Task AddAsync(ProductGroup entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.ProductGroups
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Delete(ProductGroup entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.ProductGroups.AsNoTracking().SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.ProductGroups.Remove(storage);
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
}
