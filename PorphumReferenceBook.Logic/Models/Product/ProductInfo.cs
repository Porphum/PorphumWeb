using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Product;

public sealed class ProductInfo
{
    private string? _description;

    public ProductInfo(BarCode? barCode = null, string? description = null)
    {
        BarCode = barCode;
        Description = description;
    }

    public BarCode? BarCode { get; set; }

    public string? Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrWhiteSpace(value) && value is not null)
                throw new ArgumentException();

            _description = value;
        }
    }
}
