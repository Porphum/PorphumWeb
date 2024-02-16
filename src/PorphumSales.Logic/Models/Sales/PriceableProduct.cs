using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumSales.Logic.Models.Sales;
public sealed class PriceableProduct
{
    public PriceableProduct(IMappableModel<Product, long> product, Money price, DateTime fromDate)
    {
        Product = product ?? throw new NullReferenceException();
        Price = price;
        FromDate = fromDate;
    }

    public DateTime FromDate { get; set; }

    public IMappableModel<Product, long> Product { get; set; }

    /// <summary xml:lang="ru">
    /// Цена продукта.
    /// </summary>
    public Money Price { get; }
}
