﻿using General.Abstractions.Storage.Query;
using General.Models.Query;
using General.Models.Query.Params;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
using PorphumReferenceBook.Logic.Storage.Repository.Query.Params;
using PorphumSales.Logic.Storage.Models;
using PorphumSales.Logic.Storage.Repository.Query.Params;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class SalesQueryParamFactory : ISalesQueryParamFactory
{
    public IQueryParam<ProductPrice> CreateParam(ProductsPricesParamType key, ProductsPricesParamConfig config) => key switch
    {
        ProductsPricesParamType.Limit => new LimitQueryParam<ProductPrice>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsPricesParamType.Skip => new SkipQueryParam<ProductPrice>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ProductsPricesParamType.InProductIds => new OfInPriceKeyProductsParam(config.InProductsIds ?? throw new ArgumentNullException(nameof(config.InProductsIds))),
        _ => throw new NotImplementedException()
    };
    public IQuery<IQueryParam<ProductPrice>, ProductPrice> InitQuery() => new BaseQuery<IQueryParam<ProductPrice>, ProductPrice>();

    public IQueryParam<ProductCountHistory> CreateParam(ProductsHistoriesParamType key, ProductsHistoriesParamConfig config) => key switch
    {
        ProductsHistoriesParamType.Limit => new LimitQueryParam<ProductCountHistory>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsHistoriesParamType.Skip => new SkipQueryParam<ProductCountHistory>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ProductsHistoriesParamType.OfProductId => new OfProductIdHistoreisRroductParam(config.OfProductId ?? throw new ArgumentNullException(nameof(config.OfProductId))),
        _ => throw new NotImplementedException()
    };
    IQuery<IQueryParam<ProductCountHistory>, ProductCountHistory> IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>.InitQuery() => new BaseQuery<IQueryParam<ProductCountHistory>, ProductCountHistory>();
    public IQueryParam<ProductStorage> CreateParam(ProductsStoragesParamType key, ProductsStoragesParamConfig config) => key switch
    {
        ProductsStoragesParamType.Limit => new LimitQueryParam<ProductStorage>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsStoragesParamType.Skip => new SkipQueryParam<ProductStorage>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        _ => throw new NotImplementedException()
    };
    IQuery<IQueryParam<ProductStorage>, ProductStorage> IQueryParamsFactory<ProductsStoragesParamType, ProductsStoragesParamConfig, ProductStorage>.InitQuery() => new BaseQuery<IQueryParam<ProductStorage>, ProductStorage>();
}