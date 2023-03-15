using PorphumWeb.Logic.Abstractions.Storage;
using PorphumWeb.Logic.Models;

using TUser = PorphumWeb.Logic.Storage.Models.User;
using TRole = PorphumWeb.Logic.Storage.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace PorphumWeb.Logic.Storage.Repositories;

/// <summary>
/// Репозиторий пользвотелей.
/// </summary>
public sealed class UserRepository : IUserRepository
{
    private IRepositoryContext _context;

    /// <summary>
    /// Создаёт экземпляр класса <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="context">Используемый контекст базы даннхы.</param>
    /// <exception cref="ArgumentNullException">Если один из парметро - <see langword="null"/>.</exception>
    public UserRepository(IRepositoryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public void Add(User entity)
    {
        _context.Users.Add(TUser.ConvertToStorage(entity));
    }

    /// <inheritdoc/>
    public bool Contains(User entity)
    {
        return _context.Users.Contains(TUser.ConvertToStorage(entity));
    }

    /// <inheritdoc/>
    public void Delete(User entity)
    {
        _context.Users.Remove(TUser.ConvertToStorage(entity));
    }

    /// <inheritdoc/>
    public IEnumerable<User> GetEntities()
    {
        return _context.Users.Include(x => x.Roles).Select(x => TUser.ConvertToDomain(x)).ToList();
    }

    /// <inheritdoc/>
    public User? LogInByLoginAndPassword(string login, string password)
    {
        var selectedUser = _context.Users.SingleOrDefault(x => x.Login == login);

        if (selectedUser is null || selectedUser.Password == password)
        {
            return null;
        }

        return TUser.ConvertToDomain(selectedUser);
    }

    /// <inheritdoc/>
    public void Save()
    {
        _context.SaveChanges();
    }

    /// <inheritdoc/>
    public void Update(User entity)
    {
        _context.Users.Update(TUser.ConvertToStorage(entity));
    }
}
