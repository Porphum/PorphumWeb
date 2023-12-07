using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Storage.Repository.Query.Params;

using TDocument = Models.Document;

public class OfClientDocumentsParam : IQueryParam<TDocument>
{
    private readonly long _clientId;
    private readonly DocumentType _type;

    public OfClientDocumentsParam(long clientId, DocumentType type)
    {
        _clientId = clientId;
        _type = type;
    }

    public IQueryable<TDocument> ApplyParam(IQueryable<TDocument> data) => _type switch
    {
        DocumentType.Prihod => data.Where(x => x.ClientWhoId == _clientId),
        DocumentType.Rashod => data.Where(x => x.ClientWithId == _clientId),
        _ => throw new NotImplementedException()
    };
}
