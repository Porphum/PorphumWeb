using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class ProductInfo
{
    public Product Product { get; set; }

    public string? BarCode { get; set; }

    public string? Description { get; set; }
}
