namespace PorphumReferenceBook.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища для продукта.
/// </summary>
public class Product
{
    /// <summary xml:lang="ru">
    /// Идентификатор продукта.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название продукта.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Стоимость продукта.
    /// </summary>
    public decimal Cost { get; set; }

    /// <summary xml:lang="ru">
    /// Идентификатор группы продукта.
    /// </summary>
    public int? GroupId { get; set; }

    /// <summary xml:lang="ru">
    /// Группа продукта.
    /// </summary>
    public virtual ProductGroup Group { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Информация о продукте.
    /// </summary>
    public virtual ProductExtraInfo Info { get; set; } = null!;
}
