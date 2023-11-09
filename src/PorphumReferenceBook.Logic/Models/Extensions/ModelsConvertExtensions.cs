namespace PorphumReferenceBook.Logic.Models.Extensions;

using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;

using TProduct = Storage.Models.Product;
using TProductGroup = Storage.Models.ProductGroup;
using TClient = Storage.Models.Client;
using ProductExtraInfo = Storage.Models.ProductExtraInfo;
using ClientInfo = Storage.Models.ClientInfo;
using General;


public static class ModelsConvertExtensions
{
    #region Product

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TProduct"/> в доменную модель <see cref="Product"/>.
    /// </summary>
    /// <param name="product" xml:lang="ru">Модель хранилища.</param>
    /// <param name="isFullLoad" xml:lang="ru">Флаг полной загрузки модели.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static Product ConvertToModel(this TProduct product, bool isFullLoad = true) => 
        isFullLoad 
            ? new Product(
                product.Id,
                product.Name,
                product.Group.ConvertToModel(),
                new Money(product.Cost),
                product.Info.ConvertToModel()
            ) 
            : new Product(
                product.Id,
                product.Name,
                product.Group.ConvertToModel(),
                new Money(product.Cost)
            );

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TProductGroup"/> в доменную модель <see cref="ProductGroup"/>.
    /// </summary>
    /// <param name="group" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static ProductGroup ConvertToModel(this TProductGroup group)
    {
        return new ProductGroup(group.Id, group.Name);
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="ProductExtraInfo"/> в доменную модель <see cref="ProductInfo"/>.
    /// </summary>
    /// <param name="info" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static ProductInfo ConvertToModel(this ProductExtraInfo info)
    {
        var model = new ProductInfo(
            info.Barcode is not null 
                ? new BarCode(info.Barcode)
                : null, 
            info.Description);

        return model;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="Product"/> в модель хранилища <see cref="TProduct"/>.
    /// </summary>
    /// <param name="product" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TProduct ConvertToStorage(this Product product)
    {
        var storage = new TProduct();

        storage.Name = product.Name;
        storage.Id = product.Key;
        storage.Cost = product.Price.Value;

        storage.GroupId = product.Group.Key;
        storage.Group = product.Group.ConvertToStorage();

        storage.Info = product.Info.ConvertToStorage();

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="ProductGroup"/> в модель хранилища <see cref="TProductGroup"/>.
    /// </summary>
    /// <param name="group" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TProductGroup ConvertToStorage(this ProductGroup group)
    {
        var storage = new TProductGroup();

        storage.Name = group.Name;
        storage.Id = group.Key;

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="ProductInfo"/> в модель хранилища <see cref="ProductExtraInfo"/>.
    /// </summary>
    /// <param name="group" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static ProductExtraInfo ConvertToStorage(this ProductInfo info)
    {
        var storage = new ProductExtraInfo();
        storage.Barcode = info.BarCode is null
            ? null
            : info.BarCode.Value;
        storage.Description = info.Description;

        return storage;
    }

    #endregion

    #region Client

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TClient"/> в доменную модель <see cref="Clie"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <param name="isFullLoad" xml:lang="ru">Флаг полной загрузки модели.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static Client ConvertToModel(this TClient storage, bool isFullLoad = true) => 
        !isFullLoad
            ? new Client(storage.Id, storage.Name)
            : new Client(storage.Id, storage.Name, storage.Info.ConvertToModel());

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="Client"/> в модель хранилища <see cref="TClient"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TClient ConvertToStorage(this Client model)
    {
        if (!model.IsLoaded)
        {
            throw new InvalidOperationException($"Can't convert to storage not full loaded {nameof(Client)}");
        }

        var storage = new TClient();
        
        storage.Name = model.Name;
        storage.Id = model.Key;
        storage.Info = model.IdentityInfo.ConvertToStorage();

        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="ClientInfo"/> в доменную модель <see cref="ClientIdentityInfo"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static ClientIdentityInfo ConvertToModel(this ClientInfo storage)
    {
        var model = new ClientIdentityInfo(
            storage.Inn is not null 
                ? new Clients.Inn(storage.Inn)
                : null,
            storage.Address is not null
                ? new Clients.Address(storage.Address)
                : null);

        return model;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="ClientIdentityInfo"/> в модель хранилища <see cref="ClientInfo"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static ClientInfo ConvertToStorage(this ClientIdentityInfo model)
    {
        var storage = new ClientInfo();

        if (model.Inn is not null)
        {
            storage.Inn = model.Inn.Value;
        }

        if (model.Address is not null)
        {
            storage.Address = model.Address.Value;
        }

        return storage;

    }

    #endregion
}
