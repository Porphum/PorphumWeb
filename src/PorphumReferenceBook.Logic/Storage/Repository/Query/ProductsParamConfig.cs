using General.Models.Query;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public class ProductsParamConfig : BaseQueryParamsConfig
{
    public string? NameLike { get; set; } = null!;
    public IReadOnlySet<int>? GroupsKeys { get; set; } = null!;
}
