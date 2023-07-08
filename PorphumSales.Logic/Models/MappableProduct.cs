using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models;

public class MappableProduct : IMappable<Product>
{
    public MappableProduct(Product mappedEntity, MapState state)
    {
        if (state != MapState.MapError && mappedEntity is null)
        {
            throw new ArgumentNullException();
        }

        MappedEntity = mappedEntity;
        State = state;
    }

    public Product MappedEntity { get; }

    public MapState State { get; }
}
