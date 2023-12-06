using System;
using System.Collections.Generic;

namespace PorphumSales.Logic.Storage.Models;

public partial class ProductPrice
{
    public long ProductId { get; set; }
    public decimal Price { get; set; }
    public DateTime FromDate { get; set; }
}
