namespace General;

/// <summary xml:lang="ru">
/// Класс денег в рублях.
/// </summary>
public record struct Money
{
    /// <summary xml:lang="ru">
    /// Создаёт новую сущность класса <see cref="Money"/>.
    /// </summary>
    /// <param name="value" xml:lang="ru">Количество денег.</param>
    /// <exception cref="ArgumentOutOfRangeException" xml:lang="ru">
    /// Если <paramref name="value"/> меньше или равно 0.
    /// </exception>
    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(Money)} {nameof(value)} can be greater than zero.");

        Value = value;
    }

    /// <summary xml:lang="ru">
    /// Значение количества денег.
    /// </summary>
    public decimal Value { get; }
}
