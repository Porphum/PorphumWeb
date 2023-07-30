using General;
using General.Models;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Mapper;

public class ProxyProduct : Product
{
    private static readonly string _proxyGroupName = "PROXY_GROUP";

    private static readonly string _proxyName = "PROXY_PRODUCT";


    private static readonly ProductGroup _proxyGroup = new ProductGroup(1, _proxyGroupName);

    private static readonly Money _proxyCost = new Money(0);

    public ProxyProduct(long key) : base(key, _proxyName, _proxyGroup, _proxyCost)
    {

    }

    public new void Load(ProductInfo? info)
    {
        if (IsLoaded)
        {
            throw new InvalidOperationException();
        }

        IsLoaded = true;
    }
}
