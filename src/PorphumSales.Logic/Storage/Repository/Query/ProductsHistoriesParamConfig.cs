using General.Models.Query;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class ProductsHistoriesParamConfig : BaseQueryParamsConfig
{
    public long? OfProductId { get; set; }
}
