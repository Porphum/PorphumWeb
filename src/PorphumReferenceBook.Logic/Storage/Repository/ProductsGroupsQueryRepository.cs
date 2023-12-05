using General.Models.Query;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Extensions;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic.Storage.Repository;

using TProductGroup = Models.ProductGroup;

public class ProductsGroupsQueryRepository : BaseQueryRepository<ProductGroup, TProductGroup>, IProductsGroupsQueryRepository
{
    private readonly IRepositoryContext _context;

    public ProductsGroupsQueryRepository(IRepositoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    protected override ProductGroup ConvertFromStorage(TProductGroup storage) => storage.ConvertToModel();

    protected override IQueryable<TProductGroup> GetInitQuery() => _context.ProductGroups;
}
