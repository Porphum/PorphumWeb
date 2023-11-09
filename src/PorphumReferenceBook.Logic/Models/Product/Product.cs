using General;
using General.Abstractions.Models;
using General.Models;
using System.Text.RegularExpressions;

namespace PorphumReferenceBook.Logic.Models.Product;

/// <summary xml:lang="ru">
/// Класс продукта в системе.
/// </summary>
public class Product : ILoadable, IKeyable<long>
{
    /// <summary xml:lang="ru">
    /// Шаблон для названия продукта.
    /// </summary>
    public static readonly string PRODUCT_NAME_PATTERN = @".*";

    private ProductInfo _info;

    /// <summary xml:lang="ru">
    /// Создаёт неполностью загруженный экземпляр класса <see cref="Product"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор продукта.</param>
    /// <param name="name" xml:lang="ru">Название продукта.</param>
    /// <param name="group" xml:lang="ru">Группа продукта.</param>
    /// <param name="price" xml:lang="ru">Цена продукта.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="name"/> не соответствует формату.
    /// </exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="group"/> - <see langword="null"/>.
    /// </exception>
    public Product(long key, string name, ProductGroup group, Money price)
    {
        Key = key;

        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, PRODUCT_NAME_PATTERN))
        {
            throw new ArgumentException($"" +
                $"Given {nameof(Name)} of {nameof(Product)} does not match with required pattern.", 
                nameof(name)
            );
        }    

        Name = name;
        Group = group ?? throw new ArgumentNullException(nameof(group));
        Price = price;
        IsLoaded = false;
        _info = null!;
    }

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="Product"/>.
    /// </summary>
    /// <param name="key" xml:lang="ru">Идентификатор продукта.</param>
    /// <param name="name" xml:lang="ru">Наименование продукта.</param>
    /// <param name="group" xml:lang="ru">Группа продукта.</param>
    /// <param name="price" xml:lang="ru">Цена продукта.</param>
    /// <param name="info" xml:lang="ru">Информация об продукте.</param>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="name"/> не соответствует формату.
    /// </exception>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="group"/> или <paramref name="info"/> - <see langword="null"/>.
    /// </exception>
    public Product(long key, string name, ProductGroup group, Money price, ProductInfo info)
    {
        Key = key;

        if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, PRODUCT_NAME_PATTERN))
        {
            throw new ArgumentException($"" +
                $"Given {nameof(Name)} of {nameof(Product)} does not match with required pattern.",
                nameof(name)
            );
        }

        Name = name;
        Group = group ?? throw new ArgumentNullException(nameof(group));
        Price = price;
        _info = info ?? throw new ArgumentNullException(nameof(info));
        IsLoaded = true;
    }
    
    /// <inheritdoc/>
    public long Key { get; }

    /// <summary xml:lang="ru">
    /// Название продукта.
    /// </summary>
    public string Name { get; }

    /// <summary xml:lang="ru">
    /// Группа продукта.
    /// </summary>
    public ProductGroup Group { get; set; }

    /// <summary xml:lang="ru">
    /// Цена продукта.
    /// </summary>
    public Money Price { get; }

    /// <summary xml:lang="ru">
    /// Информация об продукте.
    /// </summary>
    /// <exception cref="InvalidOperationException" xml:lang="ru">
    /// Если доступ при неполностью загруженном объекте.
    /// </exception>
    public ProductInfo Info 
    { 
        get
        {
            if (!IsLoaded)
            {
                throw new InvalidOperationException(
                    $"Can't access to {nameof(Info)} " +
                    $"for not full loaded {nameof(Product)}"
                );
            }

            return _info;
        } 
    }

    /// <inheritdoc/>
    public bool IsLoaded { get; }
}
