using General.Abstractions.Storage;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;

/// <summary xml:lang="ru">
/// Интерфейс для репозитория документов.
/// </summary>
public interface IDocumentRepository :
    IKeyableRepository<Document, long>, 
    IKeyableRepositoryWithModifiableLoad<Document, long>
{
    /// <summary xml:lang="ru">
    /// Возвращает текущую активную конфигурацию для составления документов.
    /// </summary>
    /// <returns>Текущая активная конфигурация.</returns>
    public DocumentConfig Config { get; set; }
}
