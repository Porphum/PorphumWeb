using Microsoft.Extensions.DependencyInjection;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
using PorphumReferenceBook.Logic.Storage.Repository.Query;
using PorphumSales.Logic.Abstractions.Models;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Services;
using PorphumSales.Logic.Storage.Repository;

namespace PorphumSales.Logic;

public static class Registrations
{
    public static IServiceCollection AddSalesStorage(this IServiceCollection services) =>
        services
            .AddScoped<IRepositoryContext, RepositoryContext>()
            .AddScoped<IPriceRepository, PriceRepository>()
            .AddScoped<IDocumentRepository, DocumentRepository>()
            .AddScoped<IHistoryRepository, HistoryRepository>()
            .AddScoped<IStorageRepository, StorageRepository>()
            .AddScoped<ISalesQueryParamFactory, SalesQueryParamFactory>();

    public static IServiceCollection AddSalesDocumentLogic(this IServiceCollection services) =>
        services
            .AddScoped<IDocumentStateMachine, DocumentStateMachine>();
}
