using General.Abstractions.Models;
using General.Models;
using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Client;

/// <summary xml:lang="ru">
/// Класс клиента между, которыми происходит взаимодействие в системе.
/// </summary>
public sealed class Client : ILoadable, IKeyable<long>
{
    /// <summary xml:lang="ru">
    /// Шаблон для имени клиента.
    /// </summary>
    public static readonly string CLIENT_NAME_PATTERN = @".*";

    private ClientIdentityInfo _identityInfo;

    /// <summary xml:lang="ru">
    /// Создаёт не полный экземпляр класса <see cref="Client"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор клиента.</param>
    /// <param name="name" xml:lang="ru">Название клиента.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="name"/> - не соответствует формату.
    /// </exception>
    public Client(long key, string name)
    {
        Key = key;

        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, CLIENT_NAME_PATTERN))
        {
            throw new ArgumentException(
                $"Given {nameof(Name)} of {nameof(Client)} does not match with required pattern.",
                nameof(name)
            );
        }

        Name = name;
        IsLoaded = false;
        _identityInfo = null!;
        
    }

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Client"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор клиента.</param>
    /// <param name="name" xml:lang="ru">Название клиента.</param>
    /// <param name="info" xml:lang="ru">Информация о клиенте.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="name"/> - не соответствует формату.
    /// </exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="info"/> - <see langword="null"/>.</exception>
    public Client(long key, string name, ClientIdentityInfo info)
    {
        Key = key;

        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, CLIENT_NAME_PATTERN))
        {
            throw new ArgumentException(
                $"Given {nameof(Name)} of {nameof(Client)} " +
                $"does not match with required pattern.", 
                nameof(name)
            );
        }
        Name = name;
        IsLoaded = true;
        _identityInfo = info ?? throw new ArgumentNullException(nameof(info));
    }

    
    /// <inheritdoc/>
    public long Key { get; }

    /// <summary xml:lang="ru">
    /// Название клиента.
    /// </summary>
    public string Name { get; }

    /// <summary xml:lang="ru">
    /// Информация о клиенте.
    /// </summary>
    /// <exception cref="InvalidOperationException" xml:lang="ru">
    /// Если была попытка доступа при не полностью загруженном объекте.
    /// </exception>
    public ClientIdentityInfo IdentityInfo 
    {
        get
        {
            if (!IsLoaded)
            {
                throw new InvalidOperationException(
                    $"Can't access to {nameof(IdentityInfo)} " +
                    $"for not full loaded {nameof(Client)}"
                );
            }

            return _identityInfo;
        }
    }

    /// <inheritdoc/>
    public bool IsLoaded { get; }
}
