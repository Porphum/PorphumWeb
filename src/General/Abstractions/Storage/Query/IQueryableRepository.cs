using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage.Query;

public interface IQueryableRepository<TModel, TStorageModel>
{
    IEnumerable<TModel> GetByParams(params IQueryParam<TStorageModel>[] queryParams);

    IEnumerable<TModel> GetByQuery(IQuery<IQueryParam<TStorageModel>, TStorageModel> query);

    public int GetLimit();
}
