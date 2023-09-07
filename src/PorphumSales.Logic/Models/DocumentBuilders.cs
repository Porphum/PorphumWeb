using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models;

public class DocumentBuilders : IDocumentBuilder
{
    
    public Document.Document Recreate(Document.Document document, DocumentHeader header, DocumentFill? fill = null)
    {
        throw new NotImplementedException();
    }
}
