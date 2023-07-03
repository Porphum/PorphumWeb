using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TProduct = Models.Product;

public sealed class ProductRepository : IProductRepository
{
    private IRepositoryContext _repositoryContext;

    public ProductRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    public Product? GetByKey(long key)
    {
        var find = _repositoryContext.Products
            .Include(x => x.Group)
            .Include(x => x.Info)
            .SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel();
    }

    public IEnumerable<Product> GetEntities()
    {
        return _repositoryContext.Products
            .Include(x => x.Group)
            .Include(x => x.Info)
            .AsEnumerable()
            .Select(p => p.ConvertToModel());
    }

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

    public Product? GetPartialByKey(long key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetPartialEntities()
    {
        throw new NotImplementedException();
    }
}
