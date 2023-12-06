namespace General;

/// <summary xml:lang="ru">
/// Состояния загруженной сущности.
/// </summary>
public enum MapState
{
    /// <summary xml:lang="ru">
    /// Начальное состояние.
    /// </summary>
    Init = 0,

    /// <summary xml:lang="ru">
    /// Ошибка при загрузке.
    /// </summary>
    MapError = 1,

    /// <summary xml:lang="ru">
    /// Успешно загружено.
    /// </summary>
    Success = 2
}
