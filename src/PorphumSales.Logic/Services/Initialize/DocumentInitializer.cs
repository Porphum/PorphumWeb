using PorphumReferenceBook.Logic.Models.Client;
using PorphumSales.Logic.Abstractions.Storage.Repository;
using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Models.Mapper;

namespace PorphumSales.Logic.Services.Initialize;

/// <summary xml:lang="ru">
/// Сервис для инициализации документов.
/// </summary>
public sealed class DocumentInitializer
{
    private readonly IDocumentRepository _documentRepository;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentInitializer"/>.
    /// </summary>
    /// <param name="documentRepository" xml:lang="ru">Репозиторий документов.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="documentRepository"/> - <see langword="null"/>.
    /// </exception>
    public DocumentInitializer(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
    }

    /// <summary xml:lang="ru">
    /// Создаёт новый документ заданного типа по заданным параметрам.
    /// </summary>
    /// <param name="number" xml:lang="ru">Номер документа.</param>
    /// <param name="date" xml:lang="ru">Дата документа.</param>
    /// <param name="client" xml:lang="ru">Клиент который указывается в документе.</param>
    /// <param name="type" xml:lang="ru">Тип документа.</param>
    /// <returns xml:lang="ru">Созданный документ.</returns>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если значение <paramref name="type"/> не определенно в <see cref="DocumentType"/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="client"/> - <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException" xml:lang="ru">
    /// Если была попытка создать не определенный тип документа.
    /// </exception>
    public Document InitDocument(int number, DateTime date, Client client, DocumentType type)
    {
        ArgumentNullException.ThrowIfNull(client);

        if (!Enum.IsDefined(typeof(DocumentType), type))
        {
            throw new ArgumentException();
        }

        var config = _documentRepository.GetConfig();

        var mappable = new MappableModel<Client, long>(client.Key, client);


        var header = type switch
        {
            DocumentType.Prihod => new DocumentHeader(number, date, mappable, config.Master),
            DocumentType.Rashod => new DocumentHeader(number, date, config.Master, mappable),
            _ => throw new InvalidOperationException()
        };

        return new Document(0, header, type, DocumentState.Fill, new DocumentFill());
    }
}
