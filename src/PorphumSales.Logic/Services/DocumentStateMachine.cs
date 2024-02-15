using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Services.State;

namespace PorphumSales.Logic.Services;

public class DocumentStateMachine : IDocumentStateMachine
{
    private readonly IStorageRepository _storageRepository;

    public DocumentStateMachine(IStorageRepository storageRepository)
    {
        _storageRepository = storageRepository;
    }

    public bool GoToState(ref Document document, DocumentState nextState, bool setState = true)
    {
        if (!DocumentStateTree.Transictions.ContainsKey(document.State) ||
            !DocumentStateTree.Transictions[document.State].Contains(nextState))
        {
            throw new InvalidOperationException();
        }

        IStateDocumentTransition transition = document.State switch
        {
            DocumentState.Init => nextState switch
            {
                DocumentState.Fill => new InitFillTransition(setState),
                DocumentState.Complete => new InitCompleteTransition(setState),
                _ => throw new NotImplementedException()
            },
            DocumentState.Fill => nextState switch
            {
                DocumentState.Complete => new FillToCompleteTransition(_storageRepository, setState),
                _ => throw new NotImplementedException()
            },
            _ => throw new NotImplementedException()
        };

        var result = transition.CanGo(ref document);
        return result;
    }
}
