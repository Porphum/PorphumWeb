using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage.Query;
public interface IQueryParam<TStorageModel>
{
    public IQueryable<TStorageModel> ApplyParam(IQueryable<TStorageModel> data);
}
