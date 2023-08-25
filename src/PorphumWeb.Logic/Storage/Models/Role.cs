namespace PorphumWeb.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель роли пользовтеля для хранилища.
/// </summary>
public class Role
{
    #region Converters

    /// <summary xml:lang="ru">
    /// Преобразует модель хранилища <see cref="Role"/> в доменную <see cref="Logic.Models.Role"/>. 
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель</returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="storage"/> - <see langword="null"/>.</exception>
    public static Logic.Models.Role ConvertToDomain(Role storage)
    {
        return new Logic.Models.Role(storage.Name);
    }

    /// <summary xml:lang="ru">
    /// Преобразует доменную модель <see cref="Logic.Models.Role"/> в модель хранилища <see cref="Role"/>. 
    /// </summary>
    /// <param name="domain" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="domain"/> - <see langword="null"/>.</exception>
    public static Role ConvertToStorage(Logic.Models.Role domain)
    {
        ArgumentNullException.ThrowIfNull(domain);

        return new Role()
        {
            Name = domain.Name
        };
    }

    #endregion

    /// <summary xml:lang="ru">
    /// Идентификатор роли.
    /// </summary>
    public int Id { get; set; }

    /// <summary xml:lang="ru">
    /// Название роли.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Пользовтели с этой ролью.
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
