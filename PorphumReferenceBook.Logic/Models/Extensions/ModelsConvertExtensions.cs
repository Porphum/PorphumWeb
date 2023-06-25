namespace PorphumReferenceBook.Logic.Models.Extensions;

using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;

using TProduct = PorphumReferenceBook.Logic.Storage.Models.Product;
using TClient = PorphumReferenceBook.Logic.Storage.Models.Client;

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
}
