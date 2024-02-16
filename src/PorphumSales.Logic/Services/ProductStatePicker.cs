using PorphumReferenceBook.Logic.Abstractions;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Sales;

namespace PorphumSales.Logic.Services;

public class ProductStatePicker : IProductStatePicker
{
    private readonly IStorageRepository _storageRepository;
    private readonly IPriceRepository _priceRepository;
    private readonly IReferenceBookMapper _referenceBookMapper;

    public ProductStatePicker(IPriceRepository priceRepository, IStorageRepository storageRepository, IReferenceBookMapper referenceBookMapper)
    {

        _priceRepository = priceRepository ?? throw new ArgumentNullException(nameof(priceRepository));
        _storageRepository = storageRepository ?? throw new ArgumentNullException(nameof(storageRepository));
        _referenceBookMapper = referenceBookMapper ?? throw new ArgumentNullException(nameof(referenceBookMapper));
    }

    public StateFullProduct PickState(Product product)
    {
        var quantity = _storageRepository.GetProductState(product);
        var price = _priceRepository.GetPrice(product);

        return new StateFullProduct(product, quantity, price);
    }
}
