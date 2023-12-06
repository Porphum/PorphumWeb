using General.Abstractions.Storage.Query;

namespace General.Models.Query.Params;

public class LimitQueryParam<TStorageModel> : IQueryParam<TStorageModel>
{
    private readonly int _limit;

    public LimitQueryParam(int limit)
    {
        _limit = limit;
    }


    public IQueryable<TStorageModel> ApplyParam(IQueryable<TStorageModel> data) => data.Take(_limit).AsQueryable();
}
