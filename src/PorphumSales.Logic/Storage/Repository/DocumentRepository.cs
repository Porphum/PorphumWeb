using Castle.DynamicProxy.Generators;
using General;
using General.Models.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Models.Extensions;

namespace PorphumSales.Logic.Storage.Repository;

using TDocument = Logic.Storage.Models.Document;

/// <summary xml:lang="ru">
/// Репозиторий документов.
/// </summary>
public class DocumentRepository : BaseQueryRepository<Document, TDocument>, IDocumentRepository
{
    private readonly IRepositoryContext _repositoryContext;
    private readonly IReferenceBookMapper _referenceBookMapper;
    private readonly IDocumentStateMachine _documentSateMachine;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentRepository"/>.
    /// </summary>
    /// <param name="repositoryContext" xml:lang="ru">Контекст базы данных.</param>
    /// <param name="referenceBookMapper" xml:lang="ru">Загрузчик сущностей из справочника.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если один из параметров - <see langword="null"/>.
    /// </exception>
    public DocumentRepository(IRepositoryContext repositoryContext, IReferenceBookMapper referenceBookMapper, IDocumentStateMachine documentStateMachine)
    {
        _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        _referenceBookMapper = referenceBookMapper ?? throw new ArgumentNullException(nameof(referenceBookMapper));
        _documentSateMachine = documentStateMachine ?? throw new ArgumentNullException(nameof(documentStateMachine));
    }

    private Document ValidateCurrentState(Document document)
    {
        var state = document.State;
        document.State = DocumentState.Init;

        _ = _documentSateMachine.GoToState(ref document, state);

        return document;
    }

    private Document? GetWithModByKey(long key, bool isFullLoad)
    {
        var documents = _repositoryContext.Documents
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();

        if (isFullLoad)
        {
            documents = documents.Include(x => x.DocumentsRows);
        }

        var find = documents.SingleOrDefault(x => x.Id == key);

        if (find is null)
        {
            return null;
        }

        var model = ValidateCurrentState(find.ConvertToModel(_referenceBookMapper, isFullLoad));

        return model;
    }

    private IEnumerable<Document> GetWithModEntities(bool isFullLoad)
    {
        var products = _repositoryContext.Documents
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable();

        if (isFullLoad)
        {
            products = products.Include(x => x.DocumentsRows);
        }

        return products
            .AsEnumerable()
            .Select(p => p.ConvertToModel(_referenceBookMapper, isFullLoad))
            .Select(x => ValidateCurrentState(x));
    }

    /// <inheritdoc/>
    public Document? GetByKey(long key) => GetWithModByKey(key, true);

    /// <inheritdoc/>
    public IEnumerable<Document> GetEntities() => GetWithModEntities(true);

    /// <inheritdoc/>
    public async Task<bool> ContainsAsync(Document entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        token.ThrowIfCancellationRequested();

        var storage = entity.ConvertToStorage();

        return await _repositoryContext.Documents
            .AsNoTracking()
            .ContainsAsync(storage, token)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Add(Document entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var storage = entity.ConvertToStorage();

        _repositoryContext.Documents.Add(storage);
        Save();
    }

    /// <inheritdoc/>
    public void Delete(Document entity)
    {
        var storage = entity.ConvertToStorage();

        ArgumentNullException.ThrowIfNull(entity);

        var current = _repositoryContext.Documents.AsNoTracking().SingleOrDefault(x => x.Id == storage.Id);

        if (current is null)
        {
            throw new ArgumentException("Given entity not exsist in context");
        }

        _repositoryContext.Documents.Remove(current);
        Save();
    }

    /// <inheritdoc/>
    public void Save()
    {
        _repositoryContext.SaveChanges();
    }

    /// <inheritdoc/>
    public Document? GetByKey(long key, LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModByKey(key, true),
        LoadMod.Partial => GetWithModByKey(key, true),
        _ => throw new InvalidOperationException()
    };

    /// <inheritdoc/>
    public IEnumerable<Document> GetEntities(LoadMod mod) => mod switch
    {
        LoadMod.Full => GetWithModEntities(true),
        LoadMod.Partial => GetWithModEntities(false),
        _ => throw new InvalidOperationException()
    };

    /// <inheritdoc/>
    public void Update(Document entity) => throw new NotImplementedException();

    /// <inheritdoc/>
    public DocumentConfig? Config 
    { 
        get
        {
            var storage = _repositoryContext.Configs
            .AsNoTrackingWithIdentityResolution()
            .FirstOrDefault();

            if (storage is null)
            {
                return null;
            }

            var config = storage.ConvertToModel(_referenceBookMapper);

            if (config.Master.MapState == MapState.MapError)
            {
                throw new InvalidOperationException("Can't load config correctly");
            }

            return config;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value.Master.MapState != MapState.Success)
            {
                throw new InvalidOperationException();
            }

            var storage = _repositoryContext.Configs.FirstOrDefault();
            var newStorage = value.ConvertToStorage();

            if (storage is null)
            {
                _repositoryContext.Configs.Add(newStorage);
                Save();
                return;
            }

            storage.MasterId = newStorage.MasterId;

            _repositoryContext.Configs.Add(storage);
            Save();
        }
    }

    protected override Document ConvertFromStorage(TDocument storage) => ValidateCurrentState(storage.ConvertToModel(_referenceBookMapper, true));

    protected override IQueryable<TDocument> GetInitQuery() => _repositoryContext.Documents.AsNoTracking().AsQueryable();
}
