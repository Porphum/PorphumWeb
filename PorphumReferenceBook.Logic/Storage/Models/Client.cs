using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class Client
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ClientInfo? Info { get; set; }
}
