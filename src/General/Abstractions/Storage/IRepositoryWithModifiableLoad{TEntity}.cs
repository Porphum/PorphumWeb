using General.Models;

namespace General.Abstractions.Storage;

/// <summary xml:lang="ru">
/// Описывает репозиторий сущностей <typeparamref name="TEntity"/> с функцией модифицируемой загрузки.
/// </summary>
/// <typeparam name="TEntity" xml:lang="ru">Тип сущности репозитория.</typeparam>
public interface IRepositoryWithModifiableLoad<TEntity> where TEntity : ILoadable
{
    /// <summary>
    /// Возвращает коллекцию сущностей <typeparamref name="TEntity"/>, загруженных с указанной модификацией.
    /// </summary>
    /// <param name="mod">Модификатор для загрузки.</param>
    /// <returns>Коллекция <see cref="IEnumerable{TEntity}"/> сущностей.</returns>
    public IEnumerable<TEntity> GetEntities(LoadMod mod);
}
