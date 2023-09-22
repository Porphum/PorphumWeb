namespace General.Abstractions.Models;

/// <summary xml:lang = "ru">
/// Класс для загрузки сущностей по ключам.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">Тип сущности для загрузки.</typeparam>
/// <typeparam name="TMapKey" xml:lang = "ru">Тип ключа для загрузки.</typeparam>
public interface IModelMapper<TEntity,TMapKey> where TEntity : class
{
    /// <summary xml:lang = "ru">
    /// Метод для загрузки сущности.
    /// </summary>
    /// <param name="mappable" xml:lang = "ru">Сущность переданная для загрузки.</param>
    /// <returns xml:lang = "ru">Загруженная сущность.</returns>
    public IMappableModel<TEntity, TMapKey> MapEntity(IMappableModel<TEntity, TMapKey> mappable);
}
