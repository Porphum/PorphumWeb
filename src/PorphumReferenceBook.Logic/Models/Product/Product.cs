using General.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PorphumReferenceBook.Logic.Models.Product;

public class Product : BaseLoadableModel<ProductInfo>, IKeyable<long>
{
    public static readonly string PRODUCT_NAME_PATTERN = @".*";

    private string _name = null!;
    private Money _price;

    public Product(long key, string name, ProductGroup group, Money price)
    {
        Key = key;
        Name = name;
        Group = group;
        Price = price;
    }

    public long Key { get; }

    public string Name 
    {
        get => _name;

        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();

            if (!Regex.IsMatch(value, PRODUCT_NAME_PATTERN))
                throw new ArgumentException();

            _name = value;
        }
    }

    public ProductGroup Group { get; set; }

    public Money Price
    {
        get => _price;

        set
        {
            if (value.Value == 0)
                throw new ArgumentException();

            _price = value; 
        }
    }

    public ProductInfo? Info { get; private set; } = null;

    protected override void LoadParam(ProductInfo? param)
    {
        Info = param;
    }
}
