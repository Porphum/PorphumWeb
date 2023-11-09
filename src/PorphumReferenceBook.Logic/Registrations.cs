﻿using General.Abstractions.Models;
using General.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Abstractions.Storage.Repository;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumReferenceBook.Logic.Storage.Repository;

namespace PorphumReferenceBook.Logic;

public static class Registrations
{
    public static IServiceCollection AddReferenceBookStorage(this IServiceCollection services) =>
        services
            .AddScoped<IRepositoryContext, RepositoryContext>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IKeyableRepositoryWithModifiableLoad<Product, long>, ProductRepository>()
            .AddScoped<IProductGroupRepository, ProductRepository>()
            .AddScoped<IKeyableRepositoryWithModifiableLoad<Client, long>, ClientRepository>()
            .AddScoped<IClientRepository, ClientRepository>();

    public static IServiceCollection AddReferenceBookMapper(this IServiceCollection services) =>
        services
            .AddScoped<IReferenceBookMapper, ReferenceBookMapper>();

}
