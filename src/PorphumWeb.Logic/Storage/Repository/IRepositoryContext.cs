using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Storage.Models;

namespace PorphumWeb.Logic.Storage.Repository;

public interface IRepositoryContext : IBaseRepositoryContext
{
    /// <summary xml:lang="ru">
    /// Роли пользовтелей.
    /// </summary>
    public DbSet<Role> Roles { get; }

    /// <summary xml:lang="ru">
    /// Пользовтели системы.
    /// </summary>
    public DbSet<User> Users { get; }

    /// <summary>
    /// Доступные подключения.
    /// </summary>
    public DbSet<Connection> Connections { get; }
}
