using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage.Models;

public class ClientInfo
{
    public long ClientId { get; set; }
    public string? Inn { get; set; }
    public string? Adress { get; set; }

    public virtual Client Client { get; set; } = null!;
}
