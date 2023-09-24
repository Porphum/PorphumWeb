namespace PorphumReferenceBook.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища для информации о продукте.
/// </summary>
public class ProductExtraInfo
{
    /// <summary xml:lang="ru">
    /// Идентификатор продукта.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary xml:lang="ru">
    /// Штрих-код продукта.
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary xml:lang="ru">
    /// Описание продукта.
    /// </summary>
    public string? Description { get; set; }

    /// <summary xml:lang="ru">
    /// Продукт.
    /// </summary>
    public virtual Product Product { get; set; } = null!;
}
