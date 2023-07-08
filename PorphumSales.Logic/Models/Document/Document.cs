using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class Document : BaseLoadableModel<DocumentFill>, IKeyable<long>
{
    public Document(
        long key,
        DocumentHeader header,
        DocumentType type,
        DocumentStatus status)
    {
        Key = key;
        Header = header ?? throw new ArgumentNullException();
        Type = type;
        Status = status;
    }

    protected override void LoadParam(DocumentFill? param)
    {
        Fill = param ?? throw new ArgumentNullException();
    }

    public long Key { get; }

    public DocumentHeader Header { get; }

    public DocumentFill Fill { get; private set; }

    public DocumentStatus Status { get; private set; }

    public DocumentType Type { get; }
}
