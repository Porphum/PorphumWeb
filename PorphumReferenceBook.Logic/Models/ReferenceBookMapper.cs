using General;
using General.Abstractions.Models;
using General.Abstractions.Storage;
using General.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PorphumReferenceBook.Logic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Models;

public class ReferenceBookMapper : IReferenceBookMapper
{
    private static IMappableModel<TEntity, TMapKey> MapEntityUsingRepository<TEntity, TParam, TMapKey>(
        IMappableModel<TEntity, TMapKey> mappable,
        IKeyableRepositoryWithModifiableLoad<TEntity, TParam, TMapKey> keyableRepository,
        LoadMod loadMod) where TEntity : class, IKeyable<TMapKey>, ILoadable<TParam>
    {
        var mappedEntity = keyableRepository.GetByKey(mappable.MapKey, loadMod);

        mappable.Map(mappedEntity);

        return mappable;
    }

    private readonly IKeyableRepositoryWithModifiableLoad<Product.Product, Product.ProductInfo, long> _productKeyableRepository;
    private readonly IKeyableRepositoryWithModifiableLoad<Client.Client, Client.ClientIdentityInfo, long> _clientKeyableRepository;
    
    public ReferenceBookMapper(
        IKeyableRepositoryWithModifiableLoad<Product.Product, Product.ProductInfo, long> productKeyableRepository,
        IKeyableRepositoryWithModifiableLoad<Client.Client, Client.ClientIdentityInfo, long> clientKeyableRepository)
    {
        _productKeyableRepository = productKeyableRepository;
        _clientKeyableRepository = clientKeyableRepository;
    }

    public IMappableModel<Client.Client, long> MapEntity(IMappableModel<Client.Client, long> mappable) => MapEntityUsingRepository(
        mappable,
        _clientKeyableRepository,
        loadMod: mappable.MappedEntity.IsLoaded
            ? LoadMod.Full
            : LoadMod.Partial);

    public IMappableModel<Product.Product, long> MapEntity(IMappableModel<Product.Product, long> mappable) => MapEntityUsingRepository(
        mappable,
        _productKeyableRepository,
        loadMod: mappable.MappedEntity.IsLoaded
            ? LoadMod.Full
            : LoadMod.Partial);
}
