using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Models;
public interface IDocumentStateMachine
{
    public bool GoToState(ref Document document, DocumentState nextState, bool setState = true);
}
