using General;
using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;
using System.Linq;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TProduct = Models.Product;

public sealed class ProductRepository : IProductRepository
{
    private IRepositoryContext _repositoryContext;

    public ProductRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    private Product? GetWithModByKey(long key, bool isFullLoad)
    {
        var products = _repositoryContext.Products.AsQueryable();

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
        var products = _repositoryContext.Products.AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.Info);
        }

        return products
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad));
    }

    public Product? GetByKey(long key) => GetWithModByKey(key, true);

    public IEnumerable<Product> GetEntities() => GetWithModEntities(true);

    public async Task<bool> ContainsAsync(Product entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Products
            /*.AsNoTrackingWithIdentityResolution()*/
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    public async Task AddAsync(Product entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.Products
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    public void Delete(Product entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.Products.SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.Products.Remove(storage);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public IEnumerable<ProductGroup> GetSubGroups(ProductGroup group)
    {
        var storage = group.ConvertToStorage();

        var find = _repositoryContext.ProductGroups.FirstOrDefault(x => x.Id == storage.Id);

        if (find is null)
        {
            return Enumerable.Empty<ProductGroup>();
        }

        return new List<ProductGroup>().Append(find.ConvertToModel());
    }

    IEnumerable<ProductGroup> IRepository<ProductGroup>.GetEntities()
    {
        return _repositoryContext.ProductGroups
           .AsEnumerable()
           .Select(p => p.ConvertToModel());
    }

    public Task<bool> ContainsAsync(ProductGroup entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(ProductGroup entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.ProductGroups
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    public void Delete(ProductGroup entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.ProductGroups.SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.ProductGroups.Remove(storage);
    }

    public Product? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };


    public IEnumerable<Product> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };
}
