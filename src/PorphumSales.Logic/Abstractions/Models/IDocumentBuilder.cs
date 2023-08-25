
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Models;

using PorphumSales.Logic.Models.Document;


public interface IDocumentBuilder
{
    public Document Recreate(Document document, DocumentHeader header, DocumentFill? fill = null);


}
