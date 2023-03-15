namespace PorphumWeb.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель пользовтеля для хранилища.
/// </summary>
public class User
{
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
