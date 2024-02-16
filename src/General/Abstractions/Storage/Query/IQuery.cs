namespace General.Abstractions.Storage.Query;
public interface IQuery<TQueryParam, TStorageModel> : IQueryParam<TStorageModel> where TQueryParam : IQueryParam<TStorageModel>
{
    public void Append(TQueryParam param);


}
