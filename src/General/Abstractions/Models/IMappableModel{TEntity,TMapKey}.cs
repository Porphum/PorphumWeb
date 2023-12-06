namespace General.Abstractions.Models;

/// <summary xml:lang="ru">
/// Контракт для сущности <typeparamref name="TEntity"/>, которая загружается  по ключу <typeparamref name="TMapKey"/>.
/// </summary>
/// <typeparam name="TEntity" xml:lang="ru">Класс сущности,для которой будет произведена загрузка.</typeparam>
/// <typeparam name="TMapKey" xml:lang="ru">Тип ключ, по которому происходит загрузка.</typeparam>
public interface IMappableModel<TEntity, TMapKey> where TEntity : class
{
    /// <summary xml:lang="ru">
    /// Загружаемая сущность. 
    /// Возвращает <see langword="null"/>, если <see cref="MapState"/> = <see cref="MapState.MapError"/>
    /// </summary>
    /// <exception cref="InvalidOperationException" xml:lang="ru">
    /// Если получить значение при <see cref="MapState"/> = <see cref="MapState.Init"/>. 
    /// </exception>
    public TEntity MappedEntity { get; }

    /// <summary xml:lang="ru">
    /// <list type="bullet">
    /// <listheader xml:lang="ru">Состояния загружаемой сущности:</listheader>
    /// <item xml:lang="ru"><see cref="MapState.Init"/> - сущность инициализирована</item>
    /// <item xml:lang="ru"><see cref="MapState.MapError"/> - при загрузке, произошла ошибка.</item>
    /// <item xml:lang="ru"><see cref="MapState.Success"/> - сущность успешно загружена</item>
    /// </list>
    /// </summary>
    public MapState MapState { get; }

    /// <summary xml:lang="ru">
    /// Ключ, по которому происходит загрузка сущности.
    /// </summary>
    public TMapKey MapKey { get; }

    /// <summary xml:lang="ru">
    /// Производит загрузку сущности <typeparamref name="TEntity"/>.
    /// Если <paramref name="entity"/> равен <see langword="null"/>,
    /// то <see cref="MapState"/> будет присвоено значение <see cref="MapState.MapError"/>.
    /// </summary>
    /// <param name="entity" xml:lang="ru">Сущность для загрузки.</param>
    public void Map(TEntity? entity);
}
