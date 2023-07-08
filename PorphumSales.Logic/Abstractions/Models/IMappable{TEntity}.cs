using PorphumSales.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Models;

public interface IMappable<TEntity>
{
    public TEntity MappedEntity { get; }

    public MapState State { get; }
}
