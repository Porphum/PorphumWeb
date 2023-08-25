using System;
using System.Collections.Generic;

namespace PorphumSales.Logic.Storage.Models;

public class DocumentsRow
{
    public long ProductId { get; set; }
    public long DocumentId { get; set; }
    public int Quantity { get; set; }
    public decimal Cost { get; set; }

    public virtual Document Document { get; set; } = null!;
}
