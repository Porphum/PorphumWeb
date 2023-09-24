﻿using General;
using General.Abstractions.Models;
using PorphumReferenceBook.Logic.Models.Product;

namespace PorphumSales.Logic.Models;

/// <summary xml:lang="ru">
/// Класс продукта с ценой и количеством для позиций в накладных.
/// </summary>
public class SaleProduct
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="SaleProduct"/>.
    /// </summary>
    /// <param name="product" xml:lang="ru">Продукт в позиции.</param>
    /// <param name="cost" xml:lang="ru">Стоимость продукта.</param>
    /// <param name="qunatity">Количество продуктов.</param>
    /// <exception cref="ArgumentNullException" xml:lang="ru">
    /// Если <paramref name="product"/> - <see langword=null""/>.
    /// </exception>
    /// <exception cref="ArgumentException" xml:lang="ru">
    /// Если <paramref name="qunatity"/> меньше либо равно 0.
    /// </exception>
    public SaleProduct(IMappableModel<Product, long> product, Money cost, int qunatity = 1)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));

        if (qunatity < 1)
        {
            throw new ArgumentException($"{nameof(Cost)} of {nameof(Product)} can only have values greater than zero.");
        }

        Cost = cost;
        Quantity = qunatity;
    }

    /// <summary xml:lang="ru">
    /// Продукт.
    /// </summary>
    public IMappableModel<Product, long> Product { get; }

    /// <summary xml:lang="ru">
    /// Количество.
    /// </summary>
    public int Quantity { get; }

    /// <summary xml:lang="ru">
    /// Стоимость.
    /// </summary>
    public Money Cost { get; }
}
