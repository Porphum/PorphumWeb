using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Abstractions.Storage;
using PorphumWeb.Logic.Storage.Models;

namespace PorphumWeb.Logic.Storage.Repositories;

/// <summary>
/// Контест репозитория
/// </summary>
public sealed class RepositoryContext : IRepositoryContext
{
    private readonly PorphumContext _context;

    /// <summary>
    /// Создаёт экземпляр класса <see cref="RepositoryContext"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    /// <exception cref="ArgumentNullException">Если <paramref name="context"/> - <see langword="null"/>.</exception>
    public RepositoryContext(PorphumContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public DbSet<Role> Roles => _context.Roles;

    /// <inheritdoc/>
    public DbSet<User> Users => _context.Users;

    /// <inheritdoc/>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
