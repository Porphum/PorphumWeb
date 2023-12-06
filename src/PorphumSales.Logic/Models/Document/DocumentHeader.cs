using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Client;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Класс заголовка документа.
/// </summary>
public class DocumentHeader
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentHeader"/>.
    /// </summary>
    /// <param name="number">Номер документа.</param>
    /// <param name="date">Дата накладной.</param>
    /// <param name="who">Кто составил.</param>
    /// <param name="with">С кем составили.</param>
    /// <exception cref="ArgumentNullException">
    /// Если <paramref name="who"/> или <paramref name="with"/> - <see langword="null"/>.
    /// </exception>
    public DocumentHeader(int number, DateTime date, IMappableModel<Client, long> who, IMappableModel<Client, long> with)
    {
        Number = number;
        Date = date;
        Who = who ?? throw new ArgumentNullException(nameof(who));
        With = with ?? throw new ArgumentNullException(nameof(with));
    }

    /// <summary xml:lang="ru">
    /// Номер документа.
    /// </summary>
    public int Number { get; }

    /// <summary xml:lang="ru">
    /// Дата документа.
    /// </summary>
    public DateTime Date { get; }

    /// <summary xml:lang="ru">
    /// Кто составил документ.
    /// </summary>
    public IMappableModel<Client, long> Who { get; }

    /// <summary xml:lang="ru">
    /// С кем составлен документ.
    /// </summary>
    public IMappableModel<Client, long> With { get; }
}
