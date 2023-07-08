using PorphumReferenceBook.Logic.Models.Client;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models;

public class MappableClient : IMappable<Client>
{
    public MappableClient(Client mappedEntity, MapState state)
    {
        if (state != MapState.MapError && mappedEntity is null)
        {
            throw new ArgumentNullException();
        }

        MappedEntity = mappedEntity;
        State = state;
    }

    public Client MappedEntity { get; }

    public MapState State { get; }
}
