using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

using TProduct = Logic.Storage.Models.Product;

public interface IProductsQueryRepository : IQueryableRepository<Product, TProduct>
{
}
