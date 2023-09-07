using General.Models;
using PorphumReferenceBook.Logic.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

public class ProxyClient : Client
{
    private static readonly string _proxyClientName = "PROXY_CLIENT";

    public ProxyClient(long key) : base(key, _proxyClientName) 
    { 
        
    }

    public new void Load(ClientIdentityInfo? info)
    {
        if (IsLoaded)
        {
            throw new InvalidOperationException();
        }

        IsLoaded = true;
    }
}
