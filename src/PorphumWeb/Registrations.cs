using PorphumReferenceBook.Logic;
using PorphumSales.Logic;

namespace PorphumWeb;

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
}
