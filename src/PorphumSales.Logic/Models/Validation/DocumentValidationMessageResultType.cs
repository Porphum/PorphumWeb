namespace PorphumSales.Logic.Models.Validation;

/// <summary xml:lang="ru">
/// Тип результата проверки документа.
/// </summary>
public enum DocumentValidationMessageResultType
{
    /// <summary xml:lang="ru">
    /// Проблем нет.
    /// </summary>
    Ok = 0,

    /// <summary xml:lang="ru">
    /// Ошибка загрузки в заголовке документа.
    /// </summary>
    DocumentHeaderMapError = 1,

    /// <summary xml:lang="ru">
    /// Ошибка загрузки в содержании документа.
    /// </summary>
    DocumentFillMapError = 2,

    /// <summary xml:lang="ru">
    /// Пустое содержание документа.
    /// </summary>
    DocumentFillEmpty = 2
}
