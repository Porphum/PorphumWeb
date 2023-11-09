using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Abstractions.Storage;

/// <summary xml:lang = "ru">
/// Описывает контекст базы данных справочника для репозиториев.
/// </summary>
public interface IRepositoryContext : IBaseRepositoryContext
{
    /// <summary xml:lang="ru">
    /// Продукты.
    /// </summary>
    public DbSet<Product> Products { get; }

    /// <summary xml:lang="ru">
    /// Клиенты.
    /// </summary>
    public DbSet<Client> Clients { get; }

    /// <summary xml:lang="ru">
    /// Группы продуктов.
    /// </summary>
    public DbSet<ProductGroup> ProductGroups { get; }
}
