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

    public IQuery<IQueryParam<Product>, Product> InitQuery(ProductsParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<Product>, Product>();

        if (config.NameLike is not null)
        {
            query.Append((this as IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>).CreateParam(ProductsParamType.NameLike, config));
        }

        if (config.GroupsKeys is not null)
        {
            query.Append((this as IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>).CreateParam(ProductsParamType.OfInGroupKey, config));
        }

        query.Append((this as IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>).CreateParam(ProductsParamType.Skip, config));
        query.Append((this as IQueryParamsFactory<ProductsParamType, ProductsParamConfig, Product>).CreateParam(ProductsParamType.Limit, config));

        return query;
    }

    IQuery<IQueryParam<ProductGroup>, ProductGroup> IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>.InitQuery(ProductsGroupsParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<ProductGroup>, ProductGroup>();

        if (config.NameLike is not null)
        {
            query.Append((this as IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>).CreateParam(ProductsGroupsParamType.NameLike, config));
        }

        query.Append((this as IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>).CreateParam(ProductsGroupsParamType.Skip, config));
        query.Append((this as IQueryParamsFactory<ProductsGroupsParamType, ProductsGroupsParamConfig, ProductGroup>).CreateParam(ProductsGroupsParamType.Limit, config));


        return query;
    }

    IQuery<IQueryParam<Client>, Client> IQueryParamsFactory<ClientsParamType, ClientsParamConfig, Client>.InitQuery(ClientsParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<Client>, Client>(); ;

        if (config.NameLike is not null)
        {
            query.Append(CreateParam(ClientsParamType.NameLike, config));
        }

        query.Append(CreateParam(ClientsParamType.Skip, config));
        query.Append(CreateParam(ClientsParamType.Limit, config));

        return query;
    }
}
