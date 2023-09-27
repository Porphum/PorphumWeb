using PorphumSales.Logic.Models.Document;
using PorphumSales.Logic.Models.Validation;

namespace PorphumSales.Logic.Services.Validation;

/// <summary xml:lang="ru">
/// Сервис для валидации документа.
/// </summary>
public sealed class DocumentValidator
{
    /// <summary xml:lang="ru">
    /// Проверяет модель документа и возвращает результат в виде <see cref="ValidationMessage"/>.
    /// </summary>
    /// <param name="entity">Модель для проверки.</param>
    /// <returns>Результат проверки.</returns>
    public ValidationMessage Validate(Document entity)
    {
        if (entity.Header.With.MapState != General.MapState.Success ||
            entity.Header.Who.MapState != General.MapState.Success)
        {
            return new ValidationMessage(DocumentValidationMessageResultType.DocumentHeaderMapError);
        }

        if (!entity.Fill.Rows.Any())
        {
            return new ValidationMessage(DocumentValidationMessageResultType.DocumentFillEmpty);
        }

        if (!entity.Fill.Rows.Where(x => x.Product.MapState != General.MapState.Success).Any())
        {
            return new ValidationMessage(DocumentValidationMessageResultType.DocumentFillMapError);
        }

        return new ValidationMessage(DocumentValidationMessageResultType.Ok);
    }
}
