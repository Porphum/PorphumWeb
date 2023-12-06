using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumWeb.Logic.Models.Extensions;

using TUser = Storage.Models.User;
using TRole = Storage.Models.Role;

public static class ConvertExtensions
{
    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TUser"/> в доменную модель <see cref="User"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static User ConvertToModel(this TUser storage) =>
        new User(
            storage.Login, 
            storage.Password, 
            storage.Roles
                .Select(x => x.ConvertToModel())
                .ToHashSet(),
            storage.Id
        );

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="User"/> в модель хранилища <see cref="TUser"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TUser ConvertToStorage(this User model)
    {
        var storage = new TUser();

        storage.Id = model.Key;
        storage.Login = model.Login;
        storage.Password = model.Password;
        storage.Roles = model.Roles.Select(x => x.ConvertToStorage()).ToList();
        
        return storage;
    }

    /// <summary xml:lang="ru">
    /// Конвертирует модель хранилища <see cref="TRole"/> в доменную модель <see cref="Role"/>.
    /// </summary>
    /// <param name="storage" xml:lang="ru">Модель хранилища.</param>
    /// <returns xml:lang="ru">Доменная модель.</returns>
    public static Role ConvertToModel(this TRole storage)
    {
        return new Role(storage.Name, storage.Id);
    }

    /// <summary xml:lang="ru">
    /// Конвертирует доменную модель <see cref="Role"/> в модель хранилища <see cref="TRole"/>.
    /// </summary>
    /// <param name="model" xml:lang="ru">Доменная модель.</param>
    /// <returns xml:lang="ru">Модель хранилища.</returns>
    public static TRole ConvertToStorage(this Role model)
    {
        var storage = new TRole();

        storage.Id = model.Key;
        storage.Name = model.Name;
        
        return storage;
    }
}
