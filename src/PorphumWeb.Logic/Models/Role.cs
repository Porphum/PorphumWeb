using General.Abstractions.Models;
using Microsoft.AspNetCore.Identity;

namespace PorphumWeb.Logic.Models;

/// <summary xml:lang="ru">
/// Класс-модель роли пользователя.
/// </summary>
public sealed class Role : IdentityRole, IKeyable<int>
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Role"/>.
    /// </summary>
    /// <param name="name" xml:lang="ru">Название роли.</param>
    public Role(string name, int key = 0)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException("Name of role can't be null or white spaces.");

        Name = name;
        Key = key;
    }

    /// <summary xml:lang="ru">
    /// Название роли.
    /// </summary>
    public new string Name { get; }

    /// <inheritdoc/>
    public override string Id => Key.ToString();

    /// <inheritdoc/>
    public override string NormalizedName { get => Name.Normalize(); set => base.NormalizedName = value; }

    /// <inheritdoc/>
    public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }

    /// <inheritdoc/>
    public int Key { get; }
}
