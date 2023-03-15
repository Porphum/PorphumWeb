using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Storage.Models;

namespace PorphumWeb.Logic.Abstractions.Storage;

/// <summary>
/// Описывает контекст базы данных.
/// </summary>
public interface IPorphumContext
{
    /// <summary xml:lang="ru">
    /// Роли пользовтелей.
    /// </summary>
    public DbSet<Role> Roles { get; }

    /// <summary xml:lang="ru">
    /// Пользовтели системы.
    /// </summary>
    public DbSet<User> Users { get; }
}
