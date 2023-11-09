namespace PorphumReferenceBook.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Класс модели клиента для хранилища.
/// </summary>
public class Client
{
    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public long Id { get; set; }

    /// <summary xml:lang="ru">
    /// Название клиента.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Информация о клиенте.
    /// </summary>
    public virtual ClientInfo Info { get; set; } = null!;
}
