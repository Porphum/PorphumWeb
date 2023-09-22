namespace General.Abstractions.Models;

/// <summary xml:lang = "ru">
/// Контракт для сущности, которая загружается через внешний класс по ключу.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">Сущность, которая будет загружена.</typeparam>
/// <typeparam name="TMapKey" xml:lang = "ru">Ключ, по которому происходит загрузка</typeparam>
public interface IMappableModel<TEntity, TMapKey> where TEntity : class
{
    /// <summary xml:lang = "ru">
    /// Загружаемая сущность.
    /// </summary>
    public TEntity MappedEntity { get; }

    /// <summary xml:lang = "ru">
    /// Состояние загружаемой сущности.
    /// </summary>
    public MapState MapState { get; }

    /// <summary xml:lang = "ru">
    /// Ключ, для загрузки сущности.
    /// </summary>
    public TMapKey MapKey { get; }
}
