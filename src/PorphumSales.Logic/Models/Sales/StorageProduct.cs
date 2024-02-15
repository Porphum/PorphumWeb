using General.Abstractions.Models;
using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumSales.Logic.Models.Sales;
public sealed class StorageProduct
{
    public StorageProduct(IMappableModel<Product, long> product, int count, DateTime lastUpd)
    {
        Product = product ?? throw new NullReferenceException();
        Count = count == 0 
            ? throw new ArgumentException()
            : count;

        LastUpdate = lastUpd;
    }

    public IMappableModel<Product, long> Product { get; set; }

    /// <summary xml:lang="ru">
    /// Количество продукта.
    /// </summary>
    public int Count { get; }

    public DateTime LastUpdate { get; }
}
