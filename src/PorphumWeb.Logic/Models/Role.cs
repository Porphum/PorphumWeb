namespace PorphumWeb.Logic.Models;

/// <summary xml:lang="ru">
/// Класс-модель роли пользователя.
/// </summary>
public sealed record class Role
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Role"/>.
    /// </summary>
    /// <param name="name" xml:lang="ru">Название роли.</param>
    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("Name of role can't be null or white spaces.");

        Name = name;
    }

    /// <summary xml:lang="ru">
    /// Название роли.
    /// </summary>
    public string Name { get; }
}
