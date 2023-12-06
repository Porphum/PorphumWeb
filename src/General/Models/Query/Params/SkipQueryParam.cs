using General.Abstractions.Storage.Query;


namespace General.Models.Query.Params;

public class SkipQueryParam<TStorageModel> : IQueryParam<TStorageModel>
{
    private readonly int _skip;

    public SkipQueryParam(int skip)
    {
        _skip = skip;
    }


    public IQueryable<TStorageModel> ApplyParam(IQueryable<TStorageModel> data) => data.Skip(_skip).AsQueryable();
}
