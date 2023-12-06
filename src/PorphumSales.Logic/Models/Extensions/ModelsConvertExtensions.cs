using PorphumSales.Logic.Models.Mapper;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumSales.Logic.Models.Extensions;

using PorphumSales.Logic.Models.Document;
using TDocument = Storage.Models.Document;
using TDocumentsRow = Storage.Models.DocumentsRow;
using TDocumentConfig = Storage.Models.DocumentConfig;
using ProductPrice = Storage.Models.ProductPrice;
using ProductStorage = Storage.Models.ProductStorage;
using ProductCountHistory = Storage.Models.ProductCountHistory;
using DocumentStateId = Storage.Models.DocumentStateId;
using DocumentTypeId = Storage.Models.DocumentTypeId;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumReferenceBook.Logic.Abstractions;
using General;
using PorphumSales.Logic.Models.Sales;

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
            //new General.Money(storage.Cost),
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
        //storage.Cost = model.Cost.Value;

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
    /// Конвертирует доменную модель <see cref="DocumentConfig"/> в модель хранилища <see cref="TDocumentConfig"/>.
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

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="ProductPrice"/> в доменную модель <see cref="PriceableProduct"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static PriceableProduct ConvertToModel(this ProductPrice storage, IReferenceBookMapper mapper) => new PriceableProduct(
            mapper.MapEntity(new MappableModel<Product, long>(storage.ProductId)),
            new Money(storage.Price),
            storage.FromDate

    );

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="PriceableProduct"/> в модель хранилища <see cref="ProductPrice"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static ProductPrice ConvertToStorage(this PriceableProduct model)
    {
        var storage = new ProductPrice();

        storage.ProductId = model.Product.MapKey;
        storage.Price = model.Price.Value;
        storage.FromDate = model.FromDate;

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="ProductCountHistory"/> в доменную модель <see cref="ProductHistory"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static ProductHistory ConvertToModel(this ProductCountHistory storage, IReferenceBookMapper mapper) => new ProductHistory(
            mapper.MapEntity(new MappableModel<Product, long>(storage.ProductId)),
            storage.Delta,
            storage.AccurDate,
            storage.WriteType == "trigger"
                ? WriteType.Trigger
                : WriteType.Manual,
            storage.DocumentId ?? 0
        );

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="ProductHistory"/> в модель хранилища <see cref="ProductCountHistory"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static ProductCountHistory ConvertToStorage(this ProductHistory model)
    {
        var storage = new ProductCountHistory();

        storage.ProductId = model.Product.MapKey;
        storage.Delta = model.Delta;
        storage.AccurDate = model.AccurDate;
        storage.WriteType = "manual";
        storage.DocumentId = null;
        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="ProductStorage"/> в доменную модель <see cref="StorageProduct"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="mapper" xml:lang="ru">Загрузчик для сущностей справочника.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static StorageProduct ConvertToModel(this ProductStorage storage, IReferenceBookMapper mapper) => new(
            mapper.MapEntity(new MappableModel<Product, long>(storage.ProductId!.Value)),
            (int)storage.Sum!.Value,
            storage.LastUpd!.Value
        );
}
