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
using PorphumSales.Logic.Models.Mapper;

public static class ModelsConvertExtensions
{
    public static Document ConvertToModel(this TDocument storage, bool isFullLoad = true)
    {
        var model = new Document(
            storage.Id,
            new DocumentHeader(
                storage.Number,
                storage.Date,
                new MappableClient(new ProxyClient(storage.ClientWhoId)),
                new MappableClient(new ProxyClient(storage.ClientWithId))),
            (DocumentType)storage.TypeId,
            (DocumentStatus)storage.StatusId);

        if (isFullLoad)
        {
            model.Load(new DocumentFill(storage.DocumentsRows
                .Select(x => x.ConvertToModel())
                .ToHashSet()));
        }

        return model;
    }

    public static TDocument ConvertToStorage(this Document model)
    {
        var storage = new TDocument();

        storage.Id = model.Key;
        storage.Number = model.Header.Number;
        storage.Date = model.Header.Date;
        storage.ClientWhoId = model.Header.Who.MapKey;
        storage.ClientWithId = model.Header.With.MapKey;
        storage.TypeId = (DocumentTypeId)model.Type;
        storage.StatusId = (DocumentStatusId)model.Status;
        storage.DocumentsRows = model.Fill.Rows
            .Select(x => x.ConvertToStorage())
            .Select(x => { x.DocumentId = storage.Id; return x; })
            .ToHashSet();

        return storage;
    }

    public static DocumentFillRow ConvertToModel(this TDocumentsRow storage)
    {
        return new DocumentFillRow(
            new MappableProduct(
                new ProxyProduct(storage.ProductId)), 
            new General.Money(storage.Cost),
            storage.Quantity);
    }

    public static TDocumentsRow ConvertToStorage(this DocumentFillRow model)
    {
        var storage = new TDocumentsRow();

        storage.ProductId = model.Product.MapKey;
        storage.Quantity = model.Qunatity;
        storage.Cost = model.Cost.Value;

        return storage;
    }
}
