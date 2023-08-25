using Castle.Core.Internal;
using PorphumReferenceBook.Logic.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class DocumentFill
{
    private HashSet<DocumentFillRow> _rows;

    public DocumentFill(HashSet<DocumentFillRow>? rows)
    {
        if (!rows.IsNullOrEmpty())
        {
            _rows = new HashSet<DocumentFillRow>(rows!);
            return;
        }

        _rows = new HashSet<DocumentFillRow>();
    }

    public IReadOnlySet<DocumentFillRow> Rows => _rows;

    public void Add(Product product)
    {
        
    }

    public void Remove(Product product) 
    { 
    
    }

    public void Delete(Product product)
    {

    }

    public void Clear() 
    {
       
    }
}
