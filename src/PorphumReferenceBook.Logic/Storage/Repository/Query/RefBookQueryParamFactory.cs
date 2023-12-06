using General.Abstractions.Storage.Query;
using General.Models.Query;
using General.Models.Query.Params;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
using PorphumReferenceBook.Logic.Storage.Models;
using PorphumReferenceBook.Logic.Storage.Repository.Query.Params;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class RefBookQueryParamFactory : IRefBookQueryParamFactory
{
    public IQueryParam<ProductGroup> CreateParam(ProductsGroupsParamType key, ProductsGroupsParamConfig config) => key switch
    {
        ProductsGroupsParamType.Limit => new LimitQueryParam<ProductGroup>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsGroupsParamType.Skip => new SkipQueryParam<ProductGroup>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ProductsGroupsParamType.NameLike => new NameLikeProductsGroupsParam(config.NameLike ?? throw new ArgumentNullException(nameof(config.NameLike))),
        _ => throw new NotImplementedException()
    };

    public IQueryParam<Client> CreateParam(ClientsParamType key, ClientsParamConfig config) => key switch
    {
        ClientsParamType.Limit => new LimitQueryParam<Client>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ClientsParamType.Skip => new SkipQueryParam<Client>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ClientsParamType.NameLike => new NameLikeClientsParam(config.NameLike ?? throw new ArgumentNullException(nameof(config.NameLike))),
        _ => throw new NotImplementedException()
    };

    IQueryParam<Product> IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>.CreateParam(ProductsParamType key, ProductsParamConfig config) => key switch
    {
        ProductsParamType.Limit => new LimitQueryParam<Product>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsParamType.Skip => new SkipQueryParam<Product>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ProductsParamType.NameLike => new NameLikeProductsParam(config.NameLike ?? throw new ArgumentNullException(nameof(config.NameLike))),
        ProductsParamType.OfInGroupKey => new OfInGroupKeyProductsParam(config.GroupsKeys ?? throw new ArgumentNullException(nameof(config.GroupsKeys))),
        _ => throw new NotImplementedException()
    };

    public IQuery<IQueryParam<Product>, Product> InitQuery() => new BaseQuery<IQueryParam<Product>, Product>();

    IQuery<IQueryParam<ProductGroup>, ProductGroup> IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>.InitQuery() =>
        new BaseQuery<IQueryParam<ProductGroup>, ProductGroup>();

    IQuery<IQueryParam<Client>, Client> IQueryParamsFactory<ClientsParamType, ClientsParamConfig, Client>.InitQuery() =>
        new BaseQuery<IQueryParam<Client>, Client>();
}
