using General.Abstractions.Storage.Query;

namespace General.Models.Query;

public abstract class BaseQueryRepository<TModel, TStorageModel> : IQueryableRepository<TModel, TStorageModel>
{
    protected virtual TModel ConvertFromStorage(TStorageModel storage) => throw new NotImplementedException();

    protected virtual IQueryable<TStorageModel> GetInitQuery() => throw new NotImplementedException();

    public IEnumerable<TModel> GetByParams(params IQueryParam<TStorageModel>[] queryParams)
    {
        var query = GetInitQuery();

        foreach (var param in queryParams)
        {
            query = param.ApplyParam(query);
        }

        return query.ToList().Select(x => ConvertFromStorage(x)).AsEnumerable();
    }

    public IEnumerable<TModel> GetByQuery(IQuery<IQueryParam<TStorageModel>, TStorageModel> query)
    {
        var data = GetInitQuery();

        data = query.ApplyParam(data);

        return data.ToList().Select(x => ConvertFromStorage(x)).AsEnumerable();
    }
}
