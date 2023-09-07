using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class ProductGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

}
