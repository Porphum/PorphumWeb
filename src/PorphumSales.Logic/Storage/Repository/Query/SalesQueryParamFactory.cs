using General.Abstractions.Storage.Query;
using General.Models.Query;
using General.Models.Query.Params;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
using PorphumReferenceBook.Logic.Storage.Repository.Query.Params;
using PorphumSales.Logic.Storage.Models;
using PorphumSales.Logic.Storage.Repository.Query;
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
    public IQuery<IQueryParam<ProductPrice>, ProductPrice> InitQuery(ProductsPricesParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<ProductPrice>, ProductPrice>();

        query.Append((this as IQueryParamsFactory<ProductsPricesParamType, ProductsPricesParamConfig, ProductPrice>).CreateParam(ProductsPricesParamType.Skip, config));
        query.Append((this as IQueryParamsFactory<ProductsPricesParamType, ProductsPricesParamConfig, ProductPrice>).CreateParam(ProductsPricesParamType.Limit, config));


        return query;
    }

    public IQueryParam<ProductCountHistory> CreateParam(ProductsHistoriesParamType key, ProductsHistoriesParamConfig config) => key switch
    {
        ProductsHistoriesParamType.Limit => new LimitQueryParam<ProductCountHistory>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsHistoriesParamType.Skip => new SkipQueryParam<ProductCountHistory>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        ProductsHistoriesParamType.OfProductId => new OfProductIdHistoreisRroductParam(config.OfProductId ?? throw new ArgumentNullException(nameof(config.OfProductId))),
        _ => throw new NotImplementedException()
    };
    IQuery<IQueryParam<ProductCountHistory>, ProductCountHistory> IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>.InitQuery(ProductsHistoriesParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<ProductCountHistory>, ProductCountHistory>();

        query.Append((this as IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>).CreateParam(ProductsHistoriesParamType.OfProductId, config));

        query.Append((this as IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>).CreateParam(ProductsHistoriesParamType.Skip, config));
        query.Append((this as IQueryParamsFactory<ProductsHistoriesParamType, ProductsHistoriesParamConfig, ProductCountHistory>).CreateParam(ProductsHistoriesParamType.Limit, config));

        return query;
    }
    public IQueryParam<ProductStorage> CreateParam(ProductsStoragesParamType key, ProductsStoragesParamConfig config) => key switch
    {
        ProductsStoragesParamType.Limit => new LimitQueryParam<ProductStorage>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        ProductsStoragesParamType.Skip => new SkipQueryParam<ProductStorage>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        _ => throw new NotImplementedException()
    };
    IQuery<IQueryParam<ProductStorage>, ProductStorage> IQueryParamsFactory<ProductsStoragesParamType, ProductsStoragesParamConfig, ProductStorage>.InitQuery(ProductsStoragesParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<ProductStorage>, ProductStorage>();

        query.Append((this as IQueryParamsFactory<ProductsStoragesParamType, ProductsStoragesParamConfig, ProductStorage>).CreateParam(ProductsStoragesParamType.Skip, config));
        query.Append((this as IQueryParamsFactory<ProductsStoragesParamType, ProductsStoragesParamConfig, ProductStorage>).CreateParam(ProductsStoragesParamType.Limit, config));

        return query;
    } 
    
    public IQueryParam<Document> CreateParam(DocumentsParamType key, DocumentsParamConfig config) => key switch
    {
        DocumentsParamType.Limit => new LimitQueryParam<Document>(config.Limit ?? throw new ArgumentNullException(nameof(config.Limit))),
        DocumentsParamType.Skip => new SkipQueryParam<Document>(config.Skip ?? throw new ArgumentNullException(nameof(config.Skip))),
        DocumentsParamType.OfClient => new OfClientDocumentsParam(
            config.ClientId ?? throw new ArgumentNullException(nameof(config.ClientId)),
            config.DocumentType ?? throw new ArgumentNullException(nameof(config.DocumentType))
        ),
        DocumentsParamType.OnDate => new OnDateDocumentsParam(config.OnDate ?? throw new ArgumentNullException(nameof(config.OnDate))),
        DocumentsParamType.OfType => new OfTypeDocumentsParam(config.DocumentType ?? throw new ArgumentNullException(nameof(config.DocumentType))),
        _ => throw new NotImplementedException()
    };

    IQuery<IQueryParam<Document>, Document> IQueryParamsFactory<DocumentsParamType, DocumentsParamConfig, Document>.InitQuery(DocumentsParamConfig config)
    {
        var query = new BaseQuery<IQueryParam<Document>, Document>();

        if (config.DocumentType is not null)
        {
            query.Append(CreateParam(DocumentsParamType.OfType, config));
        }
        if (config.ClientId is not null)
        {
            query.Append(CreateParam(DocumentsParamType.OfClient, config));
        }
        if (config.OnDate is not null)
        {
            query.Append(CreateParam(DocumentsParamType.OnDate, config));
        }

        query.Append(CreateParam(DocumentsParamType.Skip, config));
        query.Append(CreateParam(DocumentsParamType.Limit, config));

        return query;
    }
}
