namespace PorphumReferenceBook.Logic.Models.Product;

/// <summary xml:lang="ru">
/// Класс с информацией о продукте.
/// </summary>
public sealed class ProductInfo
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ProductInfo"/>.
    /// </summary>
    /// <param name="barCode" xml:lang="ru">Штрих-код продукта.</param>
    /// <param name="description" xml:lang="ru">Описание продукта.</param>
    /// <exception cref="ArgumentException">Если <paramref name="description"/> - не советует формату.</exception>
    public ProductInfo(BarCode? barCode = null, string? description = null)
    {
        BarCode = barCode;

        if (string.IsNullOrWhiteSpace(description) && description is not null)
        {
            throw new ArgumentException(
                $"Given {nameof(Description)} of {nameof(ProductInfo)} " +
                $"does not match with required pattern.",
                nameof(description)
            );
        }

        Description = description;
    }

    /// <summary xml:lang="ru">
    /// Штрих-код продукта.
    /// </summary>
    public BarCode? BarCode { get; }

    /// <summary xml:lang="ru">
    /// Описание продукта.
    /// </summary>
    public string? Description { get; }
}
