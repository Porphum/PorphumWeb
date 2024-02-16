using General.Models.Query;
using PorphumSales.Logic.Models.Document;

namespace PorphumSales.Logic.Storage.Repository.Query;
public class DocumentsParamConfig : BaseQueryParamsConfig
{
    public DateTime? OnDate { get; set; }

    public long? ClientId { get; set; }

    public DocumentType? DocumentType { get; set; }

}
