namespace General;

/// <summary xml:lang = "ru">
/// Класс для описания деняг.
/// </summary>
public record struct Money
{
    /// <summary xml:lang = "ru">
    /// Создаёт новый класса.
    /// </summary>
    /// <param name="value">Количество.</param>
    /// <exception cref="ArgumentOutOfRangeException">Если количество меньше или равно 0.</exception>
    public Money(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException();

        Value = value;
    }

    /// <summary xml:lang = "ru">
    /// Значение.
    /// </summary>
    public decimal Value { get; }
}
