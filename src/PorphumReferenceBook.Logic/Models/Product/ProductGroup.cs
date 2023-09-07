using General.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public sealed class ProductGroup : IKeyable<int>
{
    public static readonly string GROUP_NAME_PATTERN = @".*";

    private string _name = null!;

    public ProductGroup(int key, string name)
    {
        Key = key;
        Name = name;
    }

    public int Key { get; }

    public string Name 
    { 
        get => _name; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (!Regex.IsMatch(value, GROUP_NAME_PATTERN))
                throw new ArgumentException();

            _name = value;
        }
    }
}
