using General.Abstractions.Storage.Query;

namespace General.Models.Query;

public class BaseQuery<TQueryParam, TStorageModel> : IQuery<TQueryParam, TStorageModel> where TQueryParam : IQueryParam<TStorageModel>
{
    private List<TQueryParam> _parameters = new();

    public void Append(TQueryParam param) => _parameters.Add(param ?? throw new ArgumentNullException(nameof(param)));
    
    public IQueryable<TStorageModel> ApplyParam(IQueryable<TStorageModel> data)
    {
        foreach (var param in _parameters)
        {
            if (param is null)
            {
                continue;
            }

            data = param.ApplyParam(data);
        }

        return data;
    }
}
