using General.Models.Query;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class ProductsPricesParamConfig : BaseQueryParamsConfig
{
    public IReadOnlySet<long>? InProductsIds { get; set; } = null!;
}
