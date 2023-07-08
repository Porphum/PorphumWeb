using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Storage.Repository;

public class DocumentRepository : IDocumentRepository
{
    private readonly IProductRepository _productRepository;

    private readonly IClientRepository _clientRepository;

    private readonly IRepositoryContext _repositoryContext;

    public DocumentRepository(IProductRepository productRepository, IClientRepository clientRepository, IRepositoryContext repositoryContext)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException();
        _clientRepository = clientRepository ?? throw new ArgumentNullException();
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException();
    }

    public Task AddAsync(Document entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ContainsAsync(Document entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Document entity)
    {
        throw new NotImplementedException();
    }

    public Document? GetByKey(long key)
    {
        throw new NotImplementedException();
    }

    public DocumentConfig GetConfig()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Document> GetEntities()
    {
        throw new NotImplementedException();
    }

    public Document? GetPartialByKey(long key)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Document> GetPartialEntities()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
