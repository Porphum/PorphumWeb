using General.Abstractions.Storage.Query;
using PorphumReferenceBook.Logic.Storage.Models;
using PorphumReferenceBook.Logic.Storage.Repository.Query;

namespace PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
public interface IRefBookQueryParamFactory :
    IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>,
    IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>,
    IQueryParamsFactory<ClientsParamType, ClientsParamConfig, Client>
{
}
