using General.Abstractions.Storage.Query;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Storage.Repository.Query.Params;

using TDocuemntType = Models.DocumentTypeId;
using TDocument = Models.Document;

public class OfTypeDocumentsParam : IQueryParam<TDocument>
{
    private readonly DocumentType _type;

    public OfTypeDocumentsParam(DocumentType type)
    {
        if (DocumentType.None == type)
        {
            throw new ArgumentException();
        }

        _type = type;
    }

    public IQueryable<TDocument> ApplyParam(IQueryable<TDocument> data) => data.Where(x => x.TypeId == (TDocuemntType)_type);
}