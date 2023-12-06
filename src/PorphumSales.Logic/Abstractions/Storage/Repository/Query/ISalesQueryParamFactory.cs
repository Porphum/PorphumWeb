using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Storage.Models;
using PorphumReferenceBook.Logic.Storage.Repository.Query;
using PorphumSales.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
public interface ISalesQueryParamFactory : 
    IQueryParamsFactory<ProductsPricesParamType, ProductsPricesParamConfig, ProductPrice>,
    IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>,
    IQueryParamsFactory<ProductsStoragesParamType, ProductsStoragesParamConfig, ProductStorage>
{
}
