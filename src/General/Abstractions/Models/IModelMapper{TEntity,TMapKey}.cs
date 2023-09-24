namespace General.Abstractions.Models;

/// <summary xml:lang="ru">
/// Класс для загрузки сущностей <typeparamref name="TEntity"/> по ключам <typeparamref name="TMapKey"/>.
/// </summary>
/// <typeparam name="TEntity" xml:lang="ru">Тип сущности для загрузки.</typeparam>
/// <typeparam name="TMapKey" xml:lang="ru">Тип ключа для загрузки.</typeparam>
public interface IModelMapper<TEntity,TMapKey> where TEntity : class
{
    /// <summary xml:lang="ru">
    /// Метод для загрузки сущности. Метод принимает на вход и подаёт на выход 
    /// сущности класса имплементирующего интерфейс <see cref="IMappableModel{TEntity, TMapKey}"/>.
    /// </summary>
    /// <param name="mappable" xml:lang="ru">
    /// Сущность для загрузки.
    /// </param>
    /// <returns xml:lang="ru">Загруженная сущность.</returns>
    public IMappableModel<TEntity, TMapKey> MapEntity(IMappableModel<TEntity, TMapKey> mappable);
}
