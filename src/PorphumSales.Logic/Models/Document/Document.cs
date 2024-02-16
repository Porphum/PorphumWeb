using General.Abstractions.Models;
using General.Models;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Класс накладной в системе.
/// </summary>
public class Document : ILoadable, IKeyable<long>
{
    private DocumentFill _fill;

    /// <summary xml:lang="ru">
    /// Создаёт неполностью загруженный экземпляр класса <see cref="Document"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификаторов документа.</param>
    /// <param name="header" xml:lang="ru">Заголовок документа.</param>
    /// <param name="type" xml:lang="ru">Тип документа.</param>
    /// <param name="state" xml:lang="ru">Состояние документа.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="header"/> - <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="state"/> или <paramref name="type"/> имеют значения неопределенные в перечислениях.
    /// </exception>
    public Document(
        long key,
        DocumentHeader header,
        DocumentType type,
        DocumentState state)
    {
        Key = key;
        Header = header ?? throw new ArgumentNullException(nameof(header));

        if (!Enum.IsDefined(typeof(DocumentType), type))
        {
            throw new ArgumentException(
                $"Given value of {nameof(type)} not match with " +
                $"values of {nameof(DocumentType)}",
                nameof(type)
            );
        }

        Type = type;

        if (!Enum.IsDefined(typeof(DocumentState), state))
        {
            throw new ArgumentException(
                $"Given value of {nameof(state)} not match with " +
                $"values of {nameof(DocumentState)}",
                nameof(state)
            );
        }

        State = state;

        IsLoaded = false;
        _fill = null!;
    }

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Document"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификаторов документа.</param>
    /// <param name="header" xml:lang="ru">Заголовок документа.</param>
    /// <param name="type" xml:lang="ru">Тип документа.</param>
    /// <param name="state" xml:lang="ru">Состояние документа.</param>
    /// <param name="fill" xml:lang="ru">Содержание документа.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="header"/> или <paramref name="fill"/> - <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="state"/> или <paramref name="type"/> имеют значения неопределенные в перечислениях.
    /// </exception>
    public Document(
        long key,
        DocumentHeader header,
        DocumentType type,
        DocumentState state,
        DocumentFill fill)
    {
        Key = key;
        Header = header ?? throw new ArgumentNullException(nameof(header));

        if (!Enum.IsDefined(typeof(DocumentType), type))
        {
            throw new ArgumentException(
                $"Given value of {nameof(type)} not match with " +
                $"values of {nameof(DocumentType)}",
                nameof(type)
            );
        }

        Type = type;

        if (!Enum.IsDefined(typeof(DocumentState), state))
        {
            throw new ArgumentException(
                $"Given value of {nameof(state)} not match with " +
                $"values of {nameof(DocumentState)}",
                nameof(state)
            );
        }

        State = state;

        IsLoaded = true;
        _fill = fill ?? throw new ArgumentNullException(nameof(fill));
    }

    /// <summary xml:lang="ru">
    /// Идентификатор продукта.
    /// </summary>
    public long Key { get; }

    /// <summary>
    /// Заголовок документа.
    /// </summary>
    public DocumentHeader Header { get; }

    /// <summary xml:lang="ru">
    /// Содержание документа.
    /// </summary>
    public DocumentFill Fill
    {
        get
        {
            if (!IsLoaded)
            {
                throw new InvalidOperationException(
                    $"Can't access to {nameof(DocumentFill)} " +
                    $"for not full loaded {nameof(Fill)}"
                );
            }

            return _fill;
        }
    }

    /// <summary xml:lang="ru">
    /// Состояние документа.
    /// </summary>
    public DocumentState State { get; set; }

    /// <summary xml:lang="ru">
    /// Тип документа.
    /// </summary>
    public DocumentType Type { get; }

    /// <inheritdoc/>
    public bool IsLoaded { get; }
}
