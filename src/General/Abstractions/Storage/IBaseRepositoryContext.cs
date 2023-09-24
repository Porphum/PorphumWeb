namespace General.Abstractions.Storage;

/// <summary xml:lang="ru">
/// Интерфейс описывает базовый контекст для репозитория.
/// </summary>
public interface IBaseRepositoryContext
{
    /// <summary xml:lang="ru">
    /// Сохраняет текущие изменения.
    /// </summary>
    public void SaveChanges();
}
