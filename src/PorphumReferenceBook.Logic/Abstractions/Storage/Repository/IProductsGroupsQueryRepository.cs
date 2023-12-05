using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

using TProductGroup = Logic.Storage.Models.ProductGroup;

public interface IProductsGroupsQueryRepository : IQueryableRepository<ProductGroup, TProductGroup>
{
}
