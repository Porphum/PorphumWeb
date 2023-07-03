using System;
using System.Collections.Generic;

namespace PorphumSales.Logic.Storage.Models;

public class Document
{
    public long Id { get; set; }
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public long ClientWhoId { get; set; }
    public long ClientWithId { get; set; }
    public DocumentTypeId TypeId { get; set; }
    public DocumentStatusId StatusId { get; set; }
    public virtual ICollection<DocumentsRow> DocumentsRows { get; set; } = new HashSet<DocumentsRow>();
}
