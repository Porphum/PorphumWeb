using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PorphumWeb.Logic.Models;
using PorphumWeb.Logic.Models.Extensions;

namespace PorphumWeb.Logic.Storage.Repository;

public sealed class UsersRepository : IUserStore<User>, IRoleStore<Role>
{
    private readonly IRepositoryContext _repositoryContext;

    public UsersRepository(IRepositoryContext repositoryContext)
    {
        _repositoryContext= repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
    }

    public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        cancellationToken.ThrowIfCancellationRequested();

        var storage = role.ConvertToStorage();

        await _repositoryContext.Roles.AddAsync(storage, cancellationToken)
            .ConfigureAwait(false);

        return IdentityResult.Success;
    }
    public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        cancellationToken.ThrowIfCancellationRequested();

        var storage = user.ConvertToStorage();

        await _repositoryContext.Users.AddAsync(storage, cancellationToken)
            .ConfigureAwait(false);

        return IdentityResult.Success;
    }
    public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(role, nameof(role));
        cancellationToken.ThrowIfCancellationRequested();

        var result = await _repositoryContext.Roles
            .FirstOrDefaultAsync(x => x.Id == role.Key, cancellationToken)
            .ConfigureAwait(false);

        if (result is null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Description = $"{nameof(Role)} with id: ${role.Key} was not found"
            });
        }

        _repositoryContext.Roles.Remove(result);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        cancellationToken.ThrowIfCancellationRequested();

        var result = await _repositoryContext.Users
            .FirstOrDefaultAsync(x => x.Id == user.Key, cancellationToken)
            .ConfigureAwait(false);

        if (result is null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Description = $"{nameof(User)} with id: ${user.Key} was not found"
            });
        }

        _repositoryContext.Users.Remove(result);
        return IdentityResult.Success;
    }

    public void Dispose() { }

    public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Roles.FirstOrDefaultAsync(x => x.Id == int.Parse(roleId));

        return result is null
            ? null!
            : result.ConvertToModel();

    }

    public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Roles.FirstOrDefaultAsync(x => x.Name.Normalize() == normalizedRoleName);

        return result is null
            ? null!
            : result.ConvertToModel();

    }
    public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken) => Task.FromResult(role.NormalizedName);
    public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) => Task.FromResult(user.NormalizedUserName);

    public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken) => Task.FromResult(role.Key.ToString());
    public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken) => Task.FromResult(role.Name.ToString());
    public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) => Task.FromResult(user.Key.ToString());
    public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) => Task.FromResult(user.Login.ToString());

    public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken) => Task.CompletedTask;
    public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
    {
        var result = new Role(roleName, role.Key);

        await UpdateAsync(result, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
    {
        var result = new User(userName, user.Password, user.Roles, user.Key);

        await UpdateAsync(result, cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Roles
            .FirstOrDefaultAsync(x => x.Id == role.Key, cancellationToken)
            .ConfigureAwait(false);

        if (result is null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Description = $"{nameof(Role)} with id: ${role.Key} was not found"
            });
        }

        var newRole = role.ConvertToStorage();

        result.Name = newRole.Name;

        _repositoryContext.Roles.Update(result);

        return IdentityResult.Success;
    }
    public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Users
            .FirstOrDefaultAsync(x => x.Id == user.Key, cancellationToken)
            .ConfigureAwait(false);

        if (result is null)
        {
            return IdentityResult.Failed(new IdentityError()
            {
                Description = $"{nameof(User)} with id: ${user.Key} was not found"
            });
        }

        var newUser = user.ConvertToStorage();

        result.Login = newUser.Login;
        result.Password = newUser.Password;
        result.Roles = newUser.Roles;

        _repositoryContext.Users.Update(result);

        return IdentityResult.Success;
    }

    async Task<User> IUserStore<User>.FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Users.FirstOrDefaultAsync(x => x.Id == long.Parse(userId));

        return result is null
            ? null!
            : result.ConvertToModel();
    }

    async Task<User> IUserStore<User>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        var result = await _repositoryContext.Users.FirstOrDefaultAsync(x => x.Login.Normalize() == normalizedUserName);

        return result is null
            ? null!
            : result.ConvertToModel();
    }
}
