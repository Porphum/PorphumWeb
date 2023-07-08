using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models;

public class StorehouseProduct
{
    public StorehouseProduct(IMappable<Product> product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException();
        Quantity = quantity;
    }

    public IMappable<Product> Product { get; }

    public int Quantity { get; }
}
