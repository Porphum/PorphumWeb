using General.Models;

namespace General.Abstractions.Storage;

/// <summary xml:lang = "ru">
/// Репозиторий для получения сущностей с опцией неполной загрузки.
/// </summary>
/// <typeparam name="TEntity" xml:lang = "ru">Тип сущности репозитория.</typeparam>
public interface IRepositoryWithModifiableLoad<TEntity> where TEntity: ILoadable
{
    public IEnumerable<TEntity> GetEntities(LoadMod mod);
}
