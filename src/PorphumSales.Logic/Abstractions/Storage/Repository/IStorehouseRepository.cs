using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;

public interface IStorehouseRepository
{
    public int GetProductQuantity(Product product);

    public IEnumerable<StorehouseProduct> GetStorehouseProducts(bool isFullLoadedProducts);
}
