using General.Models.Query;

namespace PorphumReferenceBook.Logic.Storage.Repository.Query;

public sealed class ClientsParamConfig : BaseQueryParamsConfig
{
    public string? NameLike { get; set; }
}
