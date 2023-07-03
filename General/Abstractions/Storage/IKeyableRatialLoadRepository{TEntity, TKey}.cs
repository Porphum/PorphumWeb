using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage;

public interface IKeyableRatialLoadRepository<TEntity, TKey> : IPartialLoadRepository<TEntity>
{
    public TEntity? GetPartialByKey(TKey key);
}
