using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Storage;

public interface IKeyableRepositoryWithModifiableLoad<TEntity, TParam, TKey> : 
    IRepositoryWithModifiableLoad<TEntity, TParam> 
    where TEntity: ILoadable<TParam>
{
    public TEntity? GetByKey(TKey key, LoadMod mod);
}
