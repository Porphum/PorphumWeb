using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public sealed class BarCode
{
    public static readonly string BARCODE_PATTERN = @".*";

    public BarCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException();

        if (!Regex.IsMatch(value, BARCODE_PATTERN))
            throw new ArgumentException();

        Value = value;
    }   

    public string Value { get; }
}
