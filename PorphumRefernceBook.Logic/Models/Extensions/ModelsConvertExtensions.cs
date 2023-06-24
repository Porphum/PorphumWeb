namespace PorphumReferenceBook.Logic.Models.Extensions;

using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumReferenceBook.Logic.Models.Document;

using TProduct = PorphumReferenceBook.Logic.Storage.Models.Product;
using TClient = PorphumReferenceBook.Logic.Storage.Models.Client;
using TDocument = PorphumReferenceBook.Logic.Storage.Models.Document;

public static class ModelsConvertExtensions
{
    #region Product

    public static Product ConvertToModel(this TProduct product)
    {
        throw new NotImplementedException();
    }

    public static TProduct ConvertToStorage(this Product product)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Client

    public static Client ConvertToModel(this TClient product)
    {
        throw new NotImplementedException();
    }

    public static TClient ConvertToStorage(this Client product)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Document

    public static Document ConvertToModel(this TDocument product)
    {
        throw new NotImplementedException();
    }

    public static TDocument ConvertToStorage(this Document product)
    {
        throw new NotImplementedException();
    }

    #endregion
}
