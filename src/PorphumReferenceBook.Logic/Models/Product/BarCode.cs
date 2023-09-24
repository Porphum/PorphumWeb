using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Product;

/// <summary xml:lang="ru">
/// Класс штрих-кода продукта.
/// </summary>
public sealed class BarCode
{
    /// <summary xml:lang="ru">
    /// Шаблон значения штрих-кода.
    /// </summary>
    public static readonly string BARCODE_PATTERN = @".*";

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="BarCode"/>.
    /// </summary>
    /// <param name="value" xml:lang="ru">Значение штрих-кода.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="value"/> - не соответствует формату.
    /// </exception>
    public BarCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, BARCODE_PATTERN))
        {
            throw new ArgumentException(
                $"Given {nameof(Value)} of {nameof(BarCode)} " +
                $"does not match with required pattern.",
                nameof(value)
            );
        }

        Value = value;
    }

    /// <summary xml:lang="ru">
    /// Значение штрих-кода.
    /// </summary>
    public string Value { get; }
}
