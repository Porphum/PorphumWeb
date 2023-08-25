using General;
using General.Abstractions.Models;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

public abstract class BaseMappableModel<TEntity, TMapKey> : IMappableModel<TEntity, TMapKey> where TEntity : class
{
    public BaseMappableModel(TEntity? mappedEntity, bool isMapped = false)
    {
        if (isMapped && mappedEntity is null)
        {
            throw new ArgumentNullException();
        }

        IsMapped = isMapped;
        MappedEntity = mappedEntity!;
    }

    public virtual TMapKey MapKey => throw new NotImplementedException();

    public TEntity MappedEntity { get; private set; }

    public bool IsMapped { get; private set; }

    public void Map(TEntity? entity)
    {
        if (entity is null || IsMapped)
        {
            return;
        }

        MappedEntity = entity;
        IsMapped = true;
    }
}
