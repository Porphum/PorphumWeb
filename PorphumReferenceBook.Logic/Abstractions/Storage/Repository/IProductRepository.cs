using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

public interface IProductRepository : IKeyableRepository<Product, long>, IKeyableRatialLoadRepository<Product, long>, IRepository<ProductGroup>
{
    public IEnumerable<ProductGroup> GetSubGroups(ProductGroup group);
}
