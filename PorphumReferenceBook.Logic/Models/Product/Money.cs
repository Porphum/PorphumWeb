using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public record struct Money
{
    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        Value = value;
    }

    public decimal Value { get; }
}
