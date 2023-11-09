namespace PorphumReferenceBook.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища для информации о клиенте.
/// </summary>
public class ClientInfo
{
    /// <summary xml:lang="ru">
    /// Идентификатор клиента.
    /// </summary>
    public long ClientId { get; set; }

    /// <summary xml:lang="ru">
    /// Инн клиента.
    /// </summary>
    public string? Inn { get; set; }

    /// <summary xml:lang="ru">
    /// Адрес клиента.
    /// </summary>
    public string? Address { get; set; }

    /// <summary xml:lang="ru">
    /// Клиент.
    /// </summary>
    public virtual Client Client { get; set; } = null!;
}
