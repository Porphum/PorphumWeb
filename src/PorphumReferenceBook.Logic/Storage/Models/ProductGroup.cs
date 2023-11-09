namespace PorphumReferenceBook.Logic.Storage.Models;

/// <summary xml:lang="ru">
/// Модель хранилища.
/// </summary>
public class ProductGroup
{
    /// <summary xml:lang="ru">
    /// Идентификатор группы.
    /// </summary>
    public int Id { get; set; }

    /// <summary xml:lang="ru">
    /// Название группы.
    /// </summary>
    public string Name { get; set; } = null!;

    //    public int? ParentId { get; set; }

    /// <summary xml:lang="ru">
    /// Продукты с такой же группой.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

}
