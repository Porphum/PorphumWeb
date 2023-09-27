using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Models.Validation;
using PorphumSales.Logic.Services.Validation;

namespace PorphumSales.Logic.Services.Handle;

/// <summary xml:lang="ru">
/// Сервис обработки состояний документа.
/// </summary>
public sealed class DocumentStateHandler
{
    private readonly DocumentValidator _documentValidator;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentStateHandler"/>.
    /// </summary>
    /// <param name="documentValidator" xml:lang="ru">Валидатор документов.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="documentValidator"/> - <see langword="null"/>.
    /// </exception>
    public DocumentStateHandler(DocumentValidator documentValidator)
    {
        _documentValidator = documentValidator ?? throw new ArgumentNullException(nameof(documentValidator));
    }

    private Document ChangeState(Document document, DocumentState newState) => 
        new Document(document.Key, document.Header, document.Type, newState, document.Fill);

    /// <summary xml:lang="ru">
    /// Попробовать изменить состояние документа на следующее.
    /// </summary>
    /// <param name="document" xml:lang="ru">Документ для которого будет изменено состояние.</param>
    /// <param name="validationMessage" xml:lang="ru">Результат проверки документа.</param>
    /// <returns>Документ с именным состоянием.</returns>
    /// <exception cref="ArgumentNullException" xml:lang="ru">Если <paramref name="document"/> - <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException" xml:lang="ru">Если состояние документа не может быть изменено.</exception>
    public Document TryNextState(Document document, out ValidationMessage validationMessage)
    {
        ArgumentNullException.ThrowIfNull(document, nameof(document));

        if (document.State == DocumentState.Complete)
        {
            throw new ArgumentException("State of given document can't be updated.");
        }    

        var message = _documentValidator.Validate(document);
        validationMessage = message;

        if (message.ResultType != DocumentValidationMessageResultType.Ok) 
        {
            return document;
        }

        return ChangeState(document, DocumentState.Complete);
    }
}
