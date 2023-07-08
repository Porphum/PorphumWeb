using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Models.Extensions;

using PorphumSales.Logic.Models.Document;

using TDocument = PorphumSales.Logic.Storage.Models.Document;
using TDocumentsRow = PorphumSales.Logic.Storage.Models.DocumentsRow;
using DocumentStatusId = PorphumSales.Logic.Storage.Models.DocumentStatusId;
using DocumentTypeId = PorphumSales.Logic.Storage.Models.DocumentTypeId;
using System.Runtime.CompilerServices;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;

public static class ModelsConvertExtensions
{
    public static Document ConvertToModel(
        this TDocument storage, 
        IProductRepository productRepository, 
        IClientRepository clientRepository, 
        bool isFullLoad = true)
    {
        return null;
    }

    public static TDocument ConvertToStorage(
        this Document model,
        IProductRepository productRepository,
        IClientRepository clientRepository)
    {
        return null;
    }

    public static DocumentFillRow ConvertToModel(
        this TDocumentsRow storage,
        IProductRepository productRepository,
        IClientRepository clientRepository)
    {
        return null;
    }

    public static TDocumentsRow ConvertToStorage(
        this DocumentFillRow model,
        IProductRepository productRepository,
        IClientRepository clientRepository)
    {
        return null;
    }
}
