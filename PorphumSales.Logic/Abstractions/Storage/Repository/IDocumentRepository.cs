using General.Abstractions.Storage;
using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Storage.Repository;

public interface IDocumentRepository : IKeyableRepository<Document, long>, IKeyableRepositoryWithModifiableLoad<Document, DocumentFill, long>
{
    public DocumentConfig GetConfig();
}
