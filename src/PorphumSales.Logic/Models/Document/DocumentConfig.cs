using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Класс конфигурации для создания документов в системе.
/// </summary>
public class DocumentConfig : IKeyable<short>
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор конфигурации.</param>
    /// <param name="master" xml:lang="ru">От кого будут создаваться документы.</param>
    /// <exception cref="ArgumentNullException">
    /// Если <paramref name="master"/> - <see langword="null"/>.
    /// </exception>
    public DocumentConfig(short key, IMappableModel<Client, long> master)
    {
        Key = key;
        Master = master ?? throw new ArgumentNullException();
    }

    /// <summary xml:lang="ru">
    /// От кого заводятся документы.
    /// </summary>
    public IMappableModel<Client, long> Master { get; }

    /// <inheritdoc/>
    public short Key { get; }
}
