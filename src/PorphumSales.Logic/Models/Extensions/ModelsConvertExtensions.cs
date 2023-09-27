using PorphumSales.Logic.Models.Mapper;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumSales.Logic.Models.Extensions;

using PorphumSales.Logic.Models.Document;
using TDocument = Storage.Models.Document;
using TDocumentsRow = Storage.Models.DocumentsRow;
using TDocumentConfig = Storage.Models.DocumentConfig;
using DocumentStateId = Storage.Models.DocumentStateId;
using DocumentTypeId = Storage.Models.DocumentTypeId;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumReferenceBook.Logic.Abstractions;

public static class ModelsConvertExtensions
{
    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TDocument"/> в доменную модель <see cref="Document"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <param name="isFullLoad" xml:lang="ru">Флаг полной загрузки модели.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static Document ConvertToModel(this TDocument storage, IReferenceBookMapper mapper, bool isFullLoad = true) => 
        isFullLoad
            ? new Document(
            storage.Id,
            new DocumentHeader(
                storage.Number,
                storage.Date,
                mapper.MapEntity(new MappableModel<Client, long>(storage.ClientWhoId)),
                mapper.MapEntity(new MappableModel<Client, long>(storage.ClientWhoId))
            ),
            (DocumentType)storage.TypeId,
            (DocumentState)storage.StatusId
        )
            : new Document(
            storage.Id,
            new DocumentHeader(
                storage.Number,
                storage.Date,
                new MappableModel<Client, long>(storage.ClientWhoId),
                new MappableModel<Client, long>(storage.ClientWhoId)
            ),
            (DocumentType)storage.TypeId,
            (DocumentState)storage.StatusId,
            new DocumentFill(
                storage.DocumentsRows
                    .Select(x => x.ConvertToModel(mapper))
                    .ToHashSet()
            )
        );

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="Document"/> в модель хранилища <see cref="TDocument"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TDocument ConvertToStorage(this Document model)
    {
        var storage = new TDocument();

        storage.Id = model.Key;
        storage.Number = model.Header.Number;
        storage.Date = model.Header.Date;
        storage.ClientWhoId = model.Header.Who.MapKey;
        storage.ClientWithId = model.Header.With.MapKey;
        storage.TypeId = (DocumentTypeId)model.Type;
        storage.StatusId = (DocumentStateId)model.State;
        storage.DocumentsRows = model.Fill.Rows
            .Select(x => x.ConvertToStorage())
            .Select(x => { x.DocumentId = storage.Id; return x; })
            .ToHashSet();

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TDocumentsRow"/> в доменную модель <see cref="SaleProduct"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static SaleProduct ConvertToModel(this TDocumentsRow storage, IReferenceBookMapper mapper)
    {
        return new SaleProduct(
            mapper.MapEntity(new MappableModel<Product, long>(storage.ProductId)), 
            new General.Money(storage.Cost),
            storage.Quantity
        );
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="SaleProduct"/> в модель хранилища <see cref="TDocumentsRow"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TDocumentsRow ConvertToStorage(this SaleProduct model)
    {
        var storage = new TDocumentsRow();

        storage.ProductId = model.Product.MapKey;
        storage.Quantity = model.Quantity;
        storage.Cost = model.Cost.Value;

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TDocumentConfig"/> в доменную модель <see cref="DocumentConfig"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static DocumentConfig ConvertToModel(this TDocumentConfig storage, IReferenceBookMapper mapper)
    {
        return new DocumentConfig(
            storage.Id,
            mapper.MapEntity(new MappableModel<Client, long>(storage.MasterId))
        );
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="SaleProduct"/> в модель хранилища <see cref="TDocumentConfig"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TDocumentConfig ConvertToStorage(this DocumentConfig model)
    {
        var storage = new TDocumentConfig();

        storage.Id = model.Key;
        storage.MasterId = model.Master.MapKey;
        
        return storage;
    }
}
