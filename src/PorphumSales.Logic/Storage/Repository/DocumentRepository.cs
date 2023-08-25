using General;
using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Storage.Repository;

public class DocumentRepository : IDocumentRepository
{
    private readonly IRepositoryContext _repositoryContext;

    public DocumentRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    private Document? GetWithModByKey(long key, bool isFullLoad)
    {
        var documents = _repositoryContext.Documents.AsQueryable();

        if (isFullLoad)
        {
            documents = documents.Include(x => x.DocumentsRows);
        }

        var find = documents.SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        return find.ConvertToModel(isFullLoad);
    }

    private IEnumerable<Document> GetWithModEntities(bool isFullLoad)
    {
        var products = _repositoryContext.Documents.AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.DocumentsRows);
        }

        return products
            .AsEnumerable()
            .Select(p => p.ConvertToModel(isFullLoad));
    }

    public Document? GetByKey(long key) => GetWithModByKey(key, true);

    public IEnumerable<Document> GetEntities() => GetWithModEntities(true);

    public async Task<bool> ContainsAsync(Document entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Documents
            /*.AsNoTrackingWithIdentityResolution()*/
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    public async Task AddAsync(Document entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        await _repositoryContext.Documents
            .AddAsync(storage, token)
            .ConfigureAwait(false);
    }

    public void Delete(Document entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        if (_repositoryContext.Documents.SingleOrDefault(x => x.Id == storage.Id) is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.Documents.Remove(storage);
    }

    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    public Document? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };


    public IEnumerable<Document> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };

    public DocumentConfig GetConfig()
    {
        throw new NotImplementedException();
    }
}
