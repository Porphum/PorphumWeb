namespace PorphumReferenceBook.Logic.Models.Clients;

/// <summary xml:lang="ru">
/// Класс хранящий информацию об адресе.
/// </summary>
public sealed class Address
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="value" xml:lang="ru">Значение адреса.</param>
    public Address(string value)
    {
        Value = value;
    }
    

    /// <summary xml:lang="ru">
    /// Значение.
    /// </summary>
    public string Value { get; }
}
