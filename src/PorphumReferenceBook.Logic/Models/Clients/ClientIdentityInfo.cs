using PorphumReferenceBook.Logic.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models.Client;

public sealed class ClientIdentityInfo
{
    public ClientIdentityInfo(Inn? inn = null, Adress? adress = null)
    {
        Inn = inn;
        Adress = adress;
    }

    public Inn? Inn { get; set; }

    public Adress? Adress { get; set; }
}
