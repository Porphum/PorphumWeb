using PorphumReferenceBook.Logic.Models.Clients;

namespace PorphumReferenceBook.Logic.Models.Client;

/// <summary xml:lang="ru">
/// Класс с информацией о клиенте.
/// </summary>
public sealed class ClientIdentityInfo
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ClientIdentityInfo"/>.
    /// </summary>
    /// <param name="inn" xml:lang="ru">Инн клиента.</param>
    /// <param name="address" xml:lang="ru">Адрес клиента.</param>
    public ClientIdentityInfo(Inn? inn = null, Address? address = null)
    {
        Inn = inn;
        Address = address;
    }

    /// <summary xml:lang="ru">
    /// Инн клиента.
    /// </summary>
    public Inn? Inn { get; set; }

    /// <summary>
    /// Адрес клиента.
    /// </summary>
    public Address? Address { get; set; }
}
