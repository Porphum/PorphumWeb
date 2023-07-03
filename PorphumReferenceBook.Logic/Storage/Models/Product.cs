using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public int? GroupId { get; set; }

    public virtual ProductGroup Group { get; set; } = null!;

    public virtual ProductExtraInfo Info { get; set; } = null!;
}
