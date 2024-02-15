using General.Abstractions.Models;
using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Product;

/// <summary xml:lang="ru">
/// Класс группы продукта.
/// </summary>
public sealed class ProductGroup : IKeyable<int>
{
    /// <summary xml:lang="ru">
    /// Шаблон название группы продукта.
    /// </summary>
    public static readonly string GROUP_NAME_PATTERN = @".*";

    private string _name = null!;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор группы.</param>
    /// <param name="name" xml:lang="ru">Название группы.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="name"/> - не соответствует формату.
    /// </exception>
    public ProductGroup(int key, string name)
    {
        Key = key;
        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, GROUP_NAME_PATTERN))
        {
            throw new ArgumentException(
                $"Given {nameof(Name)} of {nameof(ProductGroup)} " +
                $"does not match with required pattern.",
                nameof(name)
            );
        }

        Name = name;
    }

    /// <inheritdoc/>
    public int Key { get; }

    /// <summary xml:lang="ru">
    /// Название группы.
    /// </summary>
    public string Name { get; }
}
