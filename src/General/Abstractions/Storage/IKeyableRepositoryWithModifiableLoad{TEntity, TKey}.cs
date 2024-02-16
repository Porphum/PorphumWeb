using General.Abstractions.Models;
using General.Models;

namespace General.Abstractions.Storage;

/// <summary xml:lang="ru">
/// Описывает репозиторий сущностей <typeparamref name="TEntity"/> с ключом <typeparamref name="TKey"/> 
/// с функцией модифицируемой по ключу <typeparamref name="TKey"/>.
/// </summary>
/// <typeparam name="TEntity" xml:lang="ru">Тип сущности в репозитории, имплементирующей 
/// интерфейсы <see cref="IKeyable{TKey}"/> и <see cref="ILoadable"/>.</typeparam>
/// <typeparam name="TKey" xml:lang="ru">Тип ключа для сущности в репозитории.</typeparam>
public interface IKeyableRepositoryWithModifiableLoad<TEntity, TKey> :
    IRepositoryWithModifiableLoad<TEntity>
    where TEntity : ILoadable, IKeyable<TKey>
{
    /// <summary xml:lang="ru">
    /// Возвращает сущность <typeparamref name="TEntity"/>, загруженную  с указанной 
    /// модификацией <paramref name="mod"/>, по ключу <typeparamref name="TKey"/>.
    /// </summary>
    /// <param name="key">Ключ сущности.</param>
    /// <param name="mod">Модификатор загрузки.</param>
    /// <returns>Возвращает полученную по ключу <paramref name="key"/> сущность <typeparamref name="TEntity"/>, 
    /// или <see langword="null"/> - если сущности с таким ключом <paramref name="key"/> - нет.</returns>
    public TEntity? GetByKey(TKey key, LoadMod mod);
}
