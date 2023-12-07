using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Services.State;

public class InitFillTransition : BaseStateTransition
{
    public InitFillTransition(bool isSetState) : 
        base(DocumentState.Fill, isSetState) 
    {
        var list = new List<PredicateRef<Document>>()
        {
            (ref Document doc) => doc.State != DocumentState.Init
                ? throw new InvalidOperationException()
                : true,
            IsHeaderMapped,
            IsFillMapped
        };
        Checks = list.ToArray();
    }

    protected override PredicateRef<Document>[] Checks { get; }
}
