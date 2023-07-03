using General.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public sealed class ProductGroup : IKeyable<int>
{
    public int Key => throw new NotImplementedException();

    public string Name { get; }
}
