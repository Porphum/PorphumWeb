using General.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public class Product : IKeyable<long>
{
    public long Key => throw new NotImplementedException();

    public string Name { get; }

    public ProductGroup Group { get; }

    public decimal Price { get; }
}
