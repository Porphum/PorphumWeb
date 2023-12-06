using General;
using General.Abstractions.Models;
using General.Abstractions.Storage;
using General.Models;
using PorphumReferenceBook.Logic.Abstractions;
using PorphumReferenceBook.Logic.Models.Client;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumReferenceBook.Logic;

/// <summary xml:lang="ru">
/// Класс для загрузки сущностей из справочника.
/// </summary>
public class ReferenceBookMapper : IReferenceBookMapper
{
    private static IMappableModel<TEntity, TMapKey> MapEntityUsingRepository<TEntity, TMapKey>(
        IMappableModel<TEntity, TMapKey> mappable,
        IKeyableRepositoryWithModifiableLoad<TEntity, TMapKey> keyableRepository,
        LoadMod loadMod
    ) where TEntity : class, IKeyable<TMapKey>, ILoadable
    {
        var mappedEntity = keyableRepository.GetByKey(mappable.MapKey, loadMod);

        mappable.Map(mappedEntity);

        return mappable;
    }

    private readonly IKeyableRepositoryWithModifiableLoad<Product, long> _productKeyableRepository;
    private readonly IKeyableRepositoryWithModifiableLoad<Client, long> _clientKeyableRepository;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ReferenceBookMapper"/>.
    /// </summary>
    /// <param name="productKeyableRepository" xml:lang="ru">Репозиторий продуктов.</param>
    /// <param name="clientKeyableRepository" xml:lang="ru">Репозиторий клиентов.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если один из параметров равен <see langword="null"/>.
    /// </exception>
    public ReferenceBookMapper(
        IKeyableRepositoryWithModifiableLoad<Product, long> productKeyableRepository,
        IKeyableRepositoryWithModifiableLoad<Client, long> clientKeyableRepository)
    {
        _productKeyableRepository = productKeyableRepository 
            ?? throw new ArgumentNullException(nameof(productKeyableRepository));
        
        _clientKeyableRepository = clientKeyableRepository 
            ?? throw new ArgumentNullException(nameof(clientKeyableRepository));
    }

    /// <inheritdoc/>
    public IMappableModel<Client, long> MapEntity(IMappableModel<Client, long> mappable) =>
        MapEntityUsingRepository(
            mappable,
            _clientKeyableRepository,
            loadMod: mappable.MappedEntity.IsLoaded
                ? LoadMod.Full
                : LoadMod.Partial
        );

    /// <inheritdoc/>
    public IMappableModel<Product, long> MapEntity(IMappableModel<Product, long> mappable) =>
        MapEntityUsingRepository(
            mappable,
                _productKeyableRepository,
                LoadMod.Full
        );
}
