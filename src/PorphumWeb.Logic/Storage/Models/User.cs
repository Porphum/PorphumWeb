namespace PorphumWeb.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель пользовтеля для хранилища.
/// </summary>
public class User
{
    #region Converters

    /// <summary xml:lang="ru">
    /// Преобразует модель хранилища <see cref="User"/> в доменную <see cref="Logic.Models.User"/>. 
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="storage"/> - <see langword="null"/>.</exception>
    public static Logic.Models.User ConvertToDomain(User storage)
    {
        ArgumentNullException.ThrowIfNull(storage);

        return new Logic.Models.User(
            storage.Login,
            storage.Password,
            storage.Roles
                .Select(x => Role.ConvertToDomain(x))
                .ToHashSet());
    }

    /// <summary xml:lang="ru">
    /// Преобразует доменную модель <see cref="Logic.Models.User"/> в модель хранилища <see cref="User"/>. 
    /// </summary>
    /// <param name="domain" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="domain"/> - <see langword="null"/>.</exception>
    public static User ConvertToStorage(Logic.Models.User domain)
    {
        ArgumentNullException.ThrowIfNull(domain);

        return new User()
        {
            Login = domain.Login,
            Password = domain.Password,
            Roles = domain.Roles.Select(x => Role.ConvertToStorage(x)).ToHashSet()
        };
    }

    #endregion

    /// <summary xml:lang="ru">
    /// Идентификатор пользовтеля.
    /// </summary>
    public long Id { get; set; }

    /// <summary xml:lang="ru">
    /// Логин пользовтеля.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Пароль пользовтеля.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Роди пользвотеля.
    /// </summary>
    public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();
}
