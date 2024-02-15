namespace PorphumSales.Logic.Models.Validation;

/// <summary xml:lang="ru">
/// Сообщение возвращаемое от валидатора после проверки модели.
/// </summary>
public class ValidationMessage
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ValidationMessage"/>.
    /// </summary>
    /// <param name="type" xml:lang="ru">Тип результата сообщения.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="type"/> имеет значение не определенное в <see cref="DocumentValidationMessageResultType"/>.
    /// </exception>
    public ValidationMessage(DocumentValidationMessageResultType type)
    {
        if (!Enum.IsDefined(typeof(DocumentValidationMessageResultType), type))
        {
            throw new ArgumentException($"Passed value for {nameof(DocumentValidationMessageResultType)} not declaring in enum.");
        }

        ResultType = type;
    }

    /// <summary xml:lang="ru">
    /// Тип результата проверки.
    /// </summary>
    public DocumentValidationMessageResultType ResultType { get; }
}
