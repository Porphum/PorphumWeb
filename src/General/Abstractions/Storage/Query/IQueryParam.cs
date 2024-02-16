namespace General.Abstractions.Storage.Query;
public interface IQueryParam<TStorageModel>
{
    public IQueryable<TStorageModel> ApplyParam(IQueryable<TStorageModel> data);
}
