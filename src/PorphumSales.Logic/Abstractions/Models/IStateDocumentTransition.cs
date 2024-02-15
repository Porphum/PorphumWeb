using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Abstractions.Models;
public interface IStateDocumentTransition
{
    public bool CanGo(ref Document document);
}
