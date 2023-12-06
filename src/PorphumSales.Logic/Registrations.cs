﻿using Microsoft.Extensions.DependencyInjection;
using PorphumSales.Logic.Storage.Repository;
using PorphumSales.Logic.Abstractions.Storage;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Services.Handle;
using PorphumSales.Logic.Services.Initialize;
using PorphumSales.Logic.Services.Validation;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository.Query;
using PorphumReferenceBook.Logic.Storage.Repository.Query;

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
            .AddScoped<DocumentStateHandler>()
            .AddScoped<DocumentInitializer>()
            .AddScoped<DocumentValidator>();
}
