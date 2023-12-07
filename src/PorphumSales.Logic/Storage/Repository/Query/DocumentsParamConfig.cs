using General.Models.Query;
using PorphumSales.Logic.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Storage.Repository.Query;
public class DocumentsParamConfig : BaseQueryParamsConfig
{
    public DateTime? OnDate { get; set; }

    public long? ClientId { get; set; }

    public DocumentType? DocumentType { get; set; }

}
