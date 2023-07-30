using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentFillRow
{
    public DocumentFillRow(IMappableModel<Product, long> product, Money cost, int qunatity = 1)
    {
        Product = product ?? throw new ArgumentException();

        if (qunatity < 1)
        {
            throw new ArgumentException();
        }

        Cost = cost;
        Qunatity = qunatity;
    }

    public IMappableModel<Product, long> Product { get; }

    public int Qunatity { get; set; }

    public Money Cost { get; set; }


    public void ChangeQuantity(int deltaQuantity)
    {

    }
}
