﻿using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Abstractions.Storage;


public interface IRepositoryContext : IBaseRepositoryContext
{
    public DbSet<DocumentsRow> DocumentsRows { get; }

    public DbSet<Document> Documents { get; }

    public DbSet<DocumentConfig> Configs { get; }

    public DbSet<ProductCountHistory> ProductsCountHistories { get; }
    public DbSet<ProductPrice> ProductsPrices { get; }

    public DbSet<ProductStorage> ProductsStorages { get; }
}
