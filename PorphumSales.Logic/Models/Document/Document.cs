using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models;
using PorphumSales.Logic.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Document;

public class Document : BaseLoadableModel<DocumentFill>, IKeyable<long>, IMappable
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

    public ISet<IMappableModel> GetModelsForMapping()
    {
        var set = new HashSet<IMappableModel>();

        set.Add(Header.With);
        set.Add(Header.Who);

        if (IsLoaded && Fill is not null)
        {
            foreach(var row in Fill.Rows)
            {
                set.Add(row.Product);
            }
        }

        return set;
    }

    public void MapModels(ISet<IMappableModel> mappableModels)
    {
        throw new NotImplementedException();
    }

    public long Key { get; }

    public DocumentHeader Header { get; }

    public DocumentFill? Fill { get; private set; }

    public DocumentStatus Status { get; private set; }

    public DocumentType Type { get; }
}
