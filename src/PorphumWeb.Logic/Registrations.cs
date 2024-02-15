using Microsoft.Extensions.DependencyInjection;
using PorphumWeb.Logic.Storage.Repository;

namespace PorphumWeb.Logic;

public static class Registrations
{
    public static IServiceCollection AddIdentityStorage(this IServiceCollection services) =>
        services
            .AddScoped<IRepositoryContext, RepositoryContext>();
}