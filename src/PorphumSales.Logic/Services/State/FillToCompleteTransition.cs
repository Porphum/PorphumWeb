using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Services.State;

public class FillToCompleteTransition : BaseStateTransition
{
    private readonly IStorageRepository _storageRepository;
    public FillToCompleteTransition(IStorageRepository storageRepository, bool isSetState) :
        base(DocumentState.Complete, isSetState)
    {
        _storageRepository = storageRepository;
        var list = new List<PredicateRef<Document>>()
        {
            (ref Document doc) => doc.State != DocumentState.Fill
                ? throw new InvalidOperationException()
                : true,
            IsHeaderMapped,
            IsFillMapped,
            IsCanFromStorage
        };
        Checks = list.ToArray();
    }

    private bool IsCanFromStorage(ref Document document)
    {
        if (document.Type == DocumentType.Prihod)
        {
            return true;
        }

        var state = _storageRepository.GetStorageState(
            document.Fill.Rows
                .Select(x => x.Product.MapKey)
                .ToHashSet()
        );

        var result = document.Fill.Rows.Aggregate(true, (current, x) => current && state[x.Product.MapKey] >= x.Quantity);

        return result;
    }

    protected override PredicateRef<Document>[] Checks { get; }
}
