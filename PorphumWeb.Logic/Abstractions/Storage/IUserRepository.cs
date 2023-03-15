using PorphumWeb.Logic.Models;

namespace PorphumWeb.Logic.Abstractions.Storage;

/// <summary xml:lang="ru">
/// Описывает репозиторий пользвователей.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary xml:lang="ru">
    /// Возвращает пользовтеля доступного по введенным данным для аутентификации.
    /// </summary>
    /// <param name="login xml:lang="ru"">Логин для аутентификации.</param>
    /// <param name="password" xml:lang="ru">Пароль для аутентификации.</param>
    /// <returns xml:lang="ru"><see langword="null"/> - если аутентификации не возможна, иначе пользовотеля системы.</returns>
    public User? LogInByLoginAndPassword(string login, string password);
}
