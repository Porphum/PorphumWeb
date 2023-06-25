using General.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TProduct = Models.Product;

public sealed class ProductRepository : IKeyableRepository<Product, long>
{
    private IRepositoryContext _repositoryContext;

    public ProductRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    public Product? GetByKey(long key)
    {
        var find = _repositoryContext.Products.SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel();
    }

    public IEnumerable<Product> GetEntities()
    {
        return _repositoryContext.Products.AsEnumerable().Select(p => p.ConvertToModel());
    }

    public Task<bool> ContainsAsync(Product entity, CancellationToken token = default)
    {
        var storage = entity.ConvertToStorage();

        return _repositoryContext.Products.ContainsAsync(storage, token);
    }

    public Task AddAsync(Product entity, CancellationToken token = default)
    {
        var storage = entity.ConvertToStorage();

        return _repositoryContext.Products.AddAsync(storage, token).AsTask();
    }

    public void Delete(Product entity)
    {
        var storage = entity.ConvertToStorage();

        _repositoryContext.Products.Remove(storage);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }
}
