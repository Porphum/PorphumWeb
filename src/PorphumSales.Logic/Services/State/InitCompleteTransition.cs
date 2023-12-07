using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Services.State;
public class InitCompleteTransition : BaseStateTransition
{
    public InitCompleteTransition(bool isSetState) :
        base(DocumentState.Complete, isSetState)
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
