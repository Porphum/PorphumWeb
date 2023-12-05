using General.Models.Query;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TProduct = Models.Product;

public class ProductsQueryRepository : BaseQueryRepository<Product, TProduct>, IProductsQueryRepository
{
    private readonly IRepositoryContext _context;

    public ProductsQueryRepository(IRepositoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    protected override Product ConvertFromStorage(TProduct storage) => storage.ConvertToModel();

    protected override IQueryable<TProduct> GetInitQuery() => _context.Products.Include(x => x.Group).Include(x => x.Info);
}
