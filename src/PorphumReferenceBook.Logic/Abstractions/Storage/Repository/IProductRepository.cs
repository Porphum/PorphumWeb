using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

/// <summary xml:lang = "ru">
/// Репозиторий продуктов справочника.
/// </summary>
public interface IProductRepository : 
    IKeyableRepository<Product, long>, 
    IKeyableRepositoryWithModifiableLoad<Product, long>,
    IProductGroupRepository
{
    
}
