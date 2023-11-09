using General;
using General.Abstractions.Models;

namespace PorphumSales.Logic.Models.Mapper;

/// <summary xml:lang="ru">
/// Общий класс для загружаемой модели, имплементирующий интерес <see cref="IMappableModel{TEntity, TMapKey}"/>.
/// </summary>
/// <typeparam name="TEntity" xml:lang="ru">Тип сущности для загрузки.</typeparam>
/// <typeparam name="TMapKey" xml:lang="ru">Тип ключа.</typeparam>
public class MappableModel<TEntity, TMapKey> : IMappableModel<TEntity, TMapKey> where TEntity : class
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="MappableModel{TEntity, TMapKey}"/>.
    /// </summary>
    /// <param name="mapKey" xml:lang="ru">Ключ для загрузки сущности.</param>
    public MappableModel(TMapKey mapKey)
    {
        MapKey = mapKey;
        MappedEntity = null!;
        MapState = MapState.Init;
    }

    /// <summary xml:lang="ru">
    ///  Создаёт экземпляр класса <see cref="MappableModel{TEntity, TMapKey}"/> с уже загруженной сущностью.
    /// </summary>
    /// <param name="mapKey" xml:lang="ru">Ключ для загрузки.</param>
    /// <param name="mapEntity" xml:lang="ru">Загруженная сущность.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="mapEntity"/> - <see langword="null"/>.
    /// </exception>
    public MappableModel(TMapKey mapKey, TEntity mapEntity)
    {
        MappedEntity = mapEntity ?? throw new ArgumentNullException(nameof(mapEntity));
        MapKey = mapKey;
        MapState = MapState.Success;
    }

    /// <inheritdoc/>
    public TMapKey MapKey { get; }

    /// <inheritdoc/>
    public TEntity MappedEntity { get; private set; }

    /// <inheritdoc/>
    public MapState MapState { get; private set; }

    /// <inheritdoc/>
    public void Map(TEntity? entity)
    {
        if (MapState != MapState.Init)
        {
            throw new InvalidOperationException("Can't map already mapped entity.");
        }

        MapState = entity is null ? MapState.MapError : MapState.Success;

        if (entity is null)
        {
            return;
        }

        MappedEntity = entity!;
    }
}
