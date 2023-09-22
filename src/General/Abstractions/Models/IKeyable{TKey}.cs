namespace General.Abstractions.Models;

/// <summary xml:lang = "ru">
/// Контракт для сущности имеющую ключ.
/// </summary>
/// <typeparam name="TKey" xml:lang = "ru">Тип ключа сущности.</typeparam>
public interface IKeyable<TKey>
{
    /// <summary xml:lang = "ru">
    /// Ключ.
    /// </summary>
    public TKey Key { get; }
}
