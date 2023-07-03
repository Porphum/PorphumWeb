namespace PorphumWeb.Logic.Models;

/// <summary xml:lang="ru">
/// Пользователь системы.
/// </summary>
public sealed class User
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="User"/>.
    /// </summary>
    /// <param name="login" xml:lang="ru">Логин пользователя.</param>
    /// <param name="password" xml:lang="ru">Пароль пользовтеля.</param>
    /// <param name="roles" xml:lang="ru">Роли пользовтеля.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">Если <paramref name="login"/> или <paramref name="password"/> имеют неверный формат.</exception>
    public User(string login, string password, IReadOnlySet<Role> roles = null!)
    {
        if (string.IsNullOrWhiteSpace(login))
            throw new ArgumentException("User login can't be null or white spaced");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("User password can't be null or white spaced");

        Login = login;
        Password = password;
        Roles = roles ?? new HashSet<Role>();
    }

    /// <summary xml:lang="ru">
    /// Логин пользователя.
    /// </summary>
    public string Login { get; }

    /// <summary xml:lang="ru">
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; }

    /// <summary xml:lang="ru">
    /// Роли пользвотеля.
    /// </summary>
    public IReadOnlySet<Role> Roles { get; }
}
