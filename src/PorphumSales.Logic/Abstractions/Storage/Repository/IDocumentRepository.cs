using General.Abstractions.Storage;
using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;

using TDocument = Logic.Storage.Models.Document;

/// <summary xml:lang="ru">
/// Интерфейс для репозитория документов.
/// </summary>
public interface IDocumentRepository :
    IKeyableRepository<Document, long>,
    IKeyableRepositoryWithModifiableLoad<Document, long>,
    IQueryableRepository<Document, TDocument>
{
    /// <summary xml:lang="ru">
    /// Возвращает текущую активную конфигурацию для составления документов.
    /// </summary>
    /// <returns>Текущая активная конфигурация.</returns>
    public DocumentConfig Config { get; set; }
}
