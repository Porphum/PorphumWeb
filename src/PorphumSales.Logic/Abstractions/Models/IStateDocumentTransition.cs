using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Models;
public interface IStateDocumentTransition
{
    public bool CanGo(ref Document document);
}
