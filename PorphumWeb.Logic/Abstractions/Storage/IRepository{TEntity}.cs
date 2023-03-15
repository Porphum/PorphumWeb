namespace PorphumWeb.Logic.Abstractions.Storage;

/// <summary xml:lang="ru">
/// Описывает репозиторий сущностей.
/// </summary>
/// <typeparam name="TEntity">Тип сущности репозитория.</typeparam>
public interface IRepository<TEntity>
{
    /// <summary xml:lang="ru">
    /// Возвращает все сущности находящиеся в репозитории.
    /// </summary>
    /// <returns xml:lang="ru">Колекция сущностей в репозитории.</returns>
    public IEnumerable<TEntity> GetEntities();

    /// <summary xml:lang="ru">
    /// Добавляет сущность в репозиторий.
    /// </summary>
    /// <param name="entity" xml:lang="ru">Сущность, которая будет добавлена в репозиторий.</param>
    public void Add(TEntity entity);

    /// <summary xml:lang="ru">
    /// Определяет есть ли сущность <paramref name="entity"/> в репозитории.
    /// </summary>
    /// <param name="entity" xml:lang="ru">Передаваемая сущность.</param>
    /// <returns xml:lang="ru">Вовзращает <see langword="true"/>, если <paramref name="entity"/> есть в репозитории, а иначе - <see langword="false"/>.</returns>
    public bool Contains(TEntity entity);

    /// <summary xml:lang="ru">
    /// Удаляет сущность <paramref name="entity"/> из репозиория.
    /// </summary>
    /// <param name="entity" xml:lang="ru">Удаляемая сущность.</param>
    public void Delete(TEntity entity);

    /// <summary xml:lang="ru">
    /// Обновляет сущность в репозитории.
    /// </summary>
    /// <param name="entity" xml:lang="ru">Обновленная сущность.</param>
    public void Update(TEntity entity);

    /// <summary xml:lang="ru">
    /// Сохраняет изменния в репозитории.
    /// </summary>
    public void Save();
}
