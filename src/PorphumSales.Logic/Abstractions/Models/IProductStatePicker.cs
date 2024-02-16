using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Models.Sales;

namespace PorphumSales.Logic.Abstractions.Models;

public interface IProductStatePicker
{
    public StateFullProduct PickState(Product product);
}
