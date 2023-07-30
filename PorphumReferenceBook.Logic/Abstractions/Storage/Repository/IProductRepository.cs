using General.Abstractions.Models;
using General.Abstractions.Storage;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

/// <summary>
/// 
/// </summary>
public interface IProductRepository : 
    IKeyableRepository<Product, long>, 
    IKeyableRepositoryWithModifiableLoad<Product, ProductInfo, long>, 
    IRepository<ProductGroup>
{
    public IEnumerable<ProductGroup> GetSubGroups(ProductGroup group);
}
