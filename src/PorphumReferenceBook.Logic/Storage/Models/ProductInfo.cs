using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class ProductExtraInfo
{
    public long ProductId { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }

    public virtual Product Product { get; set; } = null!;
}
