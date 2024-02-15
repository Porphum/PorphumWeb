using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Abstractions.Models;
public interface IDocumentStateMachine
{
    public bool GoToState(ref Document document, DocumentState nextState, bool setState = true);
}
