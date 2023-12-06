using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage.Query;
public interface IQuery<TQueryParam, TStorageModel> : IQueryParam<TStorageModel> where TQueryParam : IQueryParam<TStorageModel>
{
    public void Append(TQueryParam param);


}
