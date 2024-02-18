using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

/// <summary xml:lang = "ru">
/// Репозитория групп продуктов справочника.
/// </summary>
public interface IProductGroupRepository : IRepository<ProductGroup>, IKeyableRepository<ProductGroup, int>
{
    public IReadOnlyCollection<ProductGroup> GetSubGroups(int? parentGroup);
}
