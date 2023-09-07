using General.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Models;

public interface IMappableModel<TEntity, TMapKey> where TEntity : class
{
    public TEntity MappedEntity { get; }

    public bool IsMapped { get; }

    public TMapKey MapKey { get; }

    public void Map(TEntity? entity);
}
