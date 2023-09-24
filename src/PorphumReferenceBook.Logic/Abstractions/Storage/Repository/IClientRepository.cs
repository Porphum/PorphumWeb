using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

/// <summary xml:lang = "ru">
/// Репозиторий для клиентов в справочнике.
/// </summary>
public interface IClientRepository : IKeyableRepository<Client, long>, IKeyableRepositoryWithModifiableLoad<Client, long>
{
}
