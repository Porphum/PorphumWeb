using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Models;

public interface IMapper<TEntity>
{
    public TEntity Map(TEntity entity);
}
