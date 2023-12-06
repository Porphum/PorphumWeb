using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Extensions;
using PorphumSales.Logic.Models.Sales;
using PorphumSales.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;
public interface IPriceRepository : IQueryableRepository<PriceableProduct, ProductPrice>
{
    public void AddNewPrice(PriceableProduct price);

    public void DeletePrice(PriceableProduct price);
}
