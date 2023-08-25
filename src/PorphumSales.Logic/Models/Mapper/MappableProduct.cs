using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

public class MappableProduct : BaseMappableModel<Product, long>
{
    public MappableProduct(Product mappedEntity) : base(mappedEntity)
    {

    }

    public override long MapKey => MappedEntity.Key;
}
