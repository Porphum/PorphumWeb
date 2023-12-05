using PorphumReferenceBook.Logic;
using PorphumSales.Logic;
using PorphumWeb.Logic;

namespace PorphumWeb.Blazor;

public static class Registrations
{
    public static IServiceCollection AddReferenceBookServices(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddReferenceBookStorage()
            .AddReferenceBookMapper();

    public static IServiceCollection AddSalesServices(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddSalesStorage()
            .AddSalesDocumentLogic();

    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration) => services.AddIdentityStorage();
}
