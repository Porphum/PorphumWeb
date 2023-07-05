namespace PorphumReferenceBook.Logic.Models.Extensions;

using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;

using TProduct = PorphumReferenceBook.Logic.Storage.Models.Product;
using TProductGroup = PorphumReferenceBook.Logic.Storage.Models.ProductGroup;
using TClient = PorphumReferenceBook.Logic.Storage.Models.Client;
using ProductExtraInfo = PorphumReferenceBook.Logic.Storage.Models.ProductExtraInfo;
using ClientInfo = PorphumReferenceBook.Logic.Storage.Models.ClientInfo;


public static class ModelsConvertExtensions
{
    #region Product

    public static Product ConvertToModel(this TProduct product, bool isFullLoad = true)
    {
        var model = new Product(
            product.Id, 
            product.Name,
            product.Group.ConvertToModel(),
            new Money(product.Cost));
        
        if (isFullLoad)
        {
            // todo
            model.Load(product.Info is null
                ? null
                : product.Info.ConvertToModel());
        }


        return model;   
    }

    public static ProductGroup ConvertToModel(this TProductGroup group)
    {
        return new ProductGroup(group.Id, group.Name);
    }

    public static ProductInfo ConvertToModel(this ProductExtraInfo info)
    {
        var model = new ProductInfo(
            info.Barcode is not null 
                ? new BarCode(info.Barcode)
                : null, 
            info.Description);

        return model;
    }

    public static TProduct ConvertToStorage(this Product product)
    {
        var storage = new TProduct();

        storage.Name = product.Name;
        storage.Id = product.Key;
        storage.Cost = product.Price.Value;

        storage.GroupId = product.Group.Key;
        storage.Group = product.Group.ConvertToStorage();

        storage.Info = product.Info is null 
            ? null
            : product.Info.ConvertToStorage();

        return storage;
    }

    public static TProductGroup ConvertToStorage(this ProductGroup group)
    {
        var storage = new TProductGroup();

        storage.Name = group.Name;
        storage.Id = group.Key;

        return storage;
    }

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

    public static Client ConvertToModel(this TClient storage, bool isFullLoad = true)
    {
        var model = new Client(
            storage.Id,
            storage.Name);

        if (isFullLoad)
        {
            model.Load(storage.Info is null
                ? null
                : storage.Info.ConvertToModel()); 
        }

        return model;
    }

    public static TClient ConvertToStorage(this Client model)
    {
        var storage = new TClient();

        storage.Name = model.Name;
        storage.Id = model.Key;

        if (model.IdentityInfo is not null)
        {
            storage.Info = model.IdentityInfo.ConvertToStorage();
        }

        return storage;

    }

    public static ClientIdentityInfo ConvertToModel(this ClientInfo storage)
    {
        var model = new ClientIdentityInfo(
            storage.Inn is not null 
                ? new Clients.Inn(storage.Inn)
                : null,
            storage.Adress is not null
                ? new Clients.Adress(storage.Adress)
                : null);

        return model;
    }

    public static ClientInfo ConvertToStorage(this ClientIdentityInfo model)
    {
        var storage = new ClientInfo();

        if (model.Inn is not null)
        {
            storage.Inn = model.Inn.Value;
        }

        if (model.Adress is not null)
        {
            storage.Adress = model.Adress.Street;
        }

        return storage;

    }

    #endregion
}
