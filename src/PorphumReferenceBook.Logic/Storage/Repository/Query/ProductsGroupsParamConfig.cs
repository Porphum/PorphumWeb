using General.Models.Query;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class ProductsGroupsParamConfig : BaseQueryParamsConfig
{
    public string? NameLike { get; set; }
}
