using General.Abstractions.Models;
using General.Models;

namespace General.Abstractions.Storage;

/// <summary xml:lang = "ru">
/// Репозиторий с возможностью неполной загрузки по ключу.
/// </summary>
/// <typeparam name="TEntity">Тип сущности репозитория.</typeparam>
/// <typeparam name="TKey">Тип ключа.</typeparam>
public interface IKeyableRepositoryWithModifiableLoad<TEntity, TKey> : 
    IRepositoryWithModifiableLoad<TEntity> 
    where TEntity: ILoadable, IKeyable<TKey>
{
    public TEntity? GetByKey(TKey key, LoadMod mod);
}
