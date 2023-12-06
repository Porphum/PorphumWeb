namespace PorphumSales.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища для позиций в документе.
/// </summary>
public class DocumentsRow
{
    /// <summary xml:lang="ru">
    /// Идентификатор продукта в позиции.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор документа.
    /// </summary>
    public long DocumentId { get; set; }

    /// <summary xml:lang="ru">
    /// Количество продуктов.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary xml:lang="ru">
    /// Стоимость продуктов.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary xml:lang="ru">
    /// Документ.
    /// </summary>
    public virtual Document Document { get; set; } = null!;
}
