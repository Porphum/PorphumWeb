using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Storage.Models;

namespace PorphumWeb.Logic.Abstractions.Storage;

/// <summary>
/// Описывает контекст базы данных для репозитория.
/// </summary>
public interface IRepositoryContext
{
    /// <summary xml:lang="ru">
    /// Роли пользовтелей.
    /// </summary>
    public DbSet<Role> Roles { get; }

    /// <summary xml:lang="ru">
    /// Пользовтели системы.
    /// </summary>
    public DbSet<User> Users { get; }

    /// <summary xml:lang = "ru">
    /// Сохраняет текущие изменения.
    /// </summary>
    public void SaveChanges();
}
