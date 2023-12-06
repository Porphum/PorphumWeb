namespace General.Abstractions.Storage.Query;
public interface IQueryParamsFactory<TEnum, TQueryParamConfig, TStorageModel>
{
    public IQueryParam<TStorageModel> CreateParam(TEnum key, TQueryParamConfig config);

    public IQuery<IQueryParam<TStorageModel>, TStorageModel> InitQuery();
}
