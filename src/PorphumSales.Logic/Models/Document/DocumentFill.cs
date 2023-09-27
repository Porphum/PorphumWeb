using Castle.Core.Internal;
using PorphumReferenceBook.Logic.Models.Product;
using System.Collections.Immutable;

namespace PorphumSales.Logic.Models.Document;

/// <summary xml:lang="ru">
/// Класс содержания документа.
/// </summary>
public class DocumentFill
{
    private HashSet<SaleProduct> _rows;

    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="DocumentFill"/>.
    /// </summary>
    /// <param name="rows" xml:lang="ru">Позиции в документе.</param>
    public DocumentFill(HashSet<SaleProduct>? rows = null)
    {
        if (!rows.IsNullOrEmpty())
        {
            _rows = new HashSet<SaleProduct>(rows!);
            return;
        }

        _rows = new HashSet<SaleProduct>();
    }

    /// <summary xml:lang="ru">
    /// Позиции в документе.
    /// </summary>
    public IReadOnlySet<SaleProduct> Rows => _rows;
}
