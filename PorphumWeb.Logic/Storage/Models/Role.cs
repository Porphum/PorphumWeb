namespace PorphumWeb.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель роли пользовтеля для хранилища.
/// </summary>
public class Role
{
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
