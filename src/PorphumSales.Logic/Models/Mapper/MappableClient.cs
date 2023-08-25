using PorphumReferenceBook.Logic.Models.Client;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

public class MappableClient : BaseMappableModel<Client, long>
{
    public MappableClient(Client mappedEntity) : base(mappedEntity)
    {

    }

    public override long MapKey => MappedEntity.Key;
}
