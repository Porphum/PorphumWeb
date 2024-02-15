using Castle.Core.Internal;
using PorphumReferenceBook.Logic.Models.Product;
using PorphumSales.Logic.Models.Mapper;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Класс содержания документа.
/// </summary>
public class DocumentFill
{
    private List<SaleProduct> _rows; // todo better use set i think

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentFill"/>.
    /// </summary>
    /// <param name="rows" xml:lang="ru">Позиции в документе.</param>
    public DocumentFill(HashSet<SaleProduct>? rows = null)
    {
        if (!rows.IsNullOrEmpty())
        {
            _rows = new List<SaleProduct>(rows!);
            return;
        }

        _rows = new List<SaleProduct>();
    }

    /// <summary xml:lang="ru">
    /// Позиции в документе.
    /// </summary>
    public IReadOnlyList<SaleProduct> Rows => _rows;

    /// <summary xml:lang="ru">
    /// Добавляет продукт в содержание.
    /// </summary>
    /// <param name="product" xml:lang="ru">Продукт для добавления.</param>
    /// <param name="quantity">Добавляемое количество.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="product"/> - <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="quantity"/> меньше либо равно 0.
    /// </exception>
    public void AddOrUpdateProduct(Product product, int quantity = 1)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        if (quantity <= 0)
        {
            throw new ArgumentException("Can add only positive quantity of products.");
        }

        var newProduct = new MappableModel<Product, long>(product.Key, product);

        var productRow = _rows.FirstOrDefault(x => x.Product.MapKey == newProduct.MapKey);

        if (productRow is null)
        {
            _rows.Add(new SaleProduct(newProduct, quantity));
            return;
        }

        var newRow = new SaleProduct(newProduct, quantity);

        _rows.RemoveAll(x => x.Product.MapKey == product.Key);

        _rows.Add(newRow);
    }
}
