using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Product;


namespace PorphumSales.Logic.Models.Sales;

public sealed class StateFullProduct
{
    private readonly StorageProduct? _storageProduct;
    private readonly PriceableProduct? _priceableProduct;
    public StateFullProduct(Product product, StorageProduct? storageProduct, PriceableProduct? priceableProduct)
    {
        _storageProduct = storageProduct;
        _priceableProduct = priceableProduct;
        Product = product ?? throw new ArgumentNullException(nameof(product));
    }

    public Product Product { get; } 

    public int? Quantity => _storageProduct is null
        ? null
        : _storageProduct.Count;

    public Money? Price => _priceableProduct is null
        ? null
        : _priceableProduct.Price;
}
