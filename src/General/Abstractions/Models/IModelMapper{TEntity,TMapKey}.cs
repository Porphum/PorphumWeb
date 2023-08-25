using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Abstractions.Models;

public interface IModelMapper<TEntity,TMapKey> where TEntity : class
{
    public IMappableModel<TEntity, TMapKey> MapEntity(IMappableModel<TEntity, TMapKey> mappable);
}
