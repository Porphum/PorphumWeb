using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Abstractions;

/// <summary xml:lang="ru">
/// Интерфейс для загрузки сущностей справочника.
/// </summary>
public interface IReferenceBookMapper : IModelMapper<Client, long>, IModelMapper<Product, long>
{
}
