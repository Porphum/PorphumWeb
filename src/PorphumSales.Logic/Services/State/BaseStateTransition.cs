using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Services.State;

public delegate bool PredicateRef<T>(ref T item);

public abstract class BaseStateTransition : IStateDocumentTransition
{
    private readonly DocumentState _stateToSet;
    private readonly bool _setState;

    protected virtual PredicateRef<Document>[] Checks => throw new NotImplementedException();

    public BaseStateTransition(DocumentState state, bool isSetState)
    {
        _stateToSet = state;
        _setState = isSetState;
    }

    protected static bool IsHeaderMapped(ref Document document)
    {
        if (document.Header.Who.MapState != General.MapState.Success || document.Header.Who.MapState != General.MapState.Success)
        {
            document.State = DocumentState.HeaderMapError;
            return false;
        }

        return true;
    }

    protected static bool IsFillMapped(ref Document document)
    {
        var result = true;

        result = document.Fill.Rows.Aggregate(result, (current, row) => row.Product.MapState == General.MapState.Success && current);

        return result;
    }

    public bool CanGo(ref Document document)
    {
        var result = true;
        foreach (var check in Checks)
        {
            result = check.Invoke(ref document);

            if (!result)
            {
                break;
            }
        }

        if (result && _setState)
        {
            document.State = _stateToSet;
        }

        return result;
    }
}
