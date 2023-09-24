using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Clients;

/// <summary xml:lang="ru">
/// Класс хранящий и проверяющий инн клиентов.
/// </summary>
public record class Inn
{
    /// <summary xml:lang="ru">
    /// Шаблон для проверки инн.
    /// </summary>
    public static readonly string INN_PATTERN = @".*";

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Inn"/>.
    /// </summary>
    /// <param name="value">Значение ИНН.</param>
    /// <exception cref="ArgumentException">
    /// Если <paramref name="value"/> - не соответствует формату.
    /// </exception>
    public Inn(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException();

        if (!Regex.IsMatch(value, INN_PATTERN))
            throw new ArgumentException();

        Value = value;
    }

    /// <summary>
    /// Значение.
    /// </summary>
    public string Value { get; }
}
