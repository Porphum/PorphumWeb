namespace General.Models.Query;

public abstract class BaseQueryParamsConfig
{
    public int? Limit { get; set; } = null!;

    public int? Skip { get; set; } = null!;
}
