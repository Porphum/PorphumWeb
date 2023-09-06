﻿using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Abstractions.Storage;

/// <summary>
/// Описывает контекст базы данных для репозитория.
/// </summary>
public interface IRepositoryContext : IBaseRepositoryContext
{
    /// <summary xml:lang="ru">
    /// Роли пользовтелей.
    /// </summary>
    public DbSet<Product> Products { get; }

    /// <summary xml:lang="ru">
    /// Пользовтели системы.
    /// </summary>
    public DbSet<Client> Clients { get; }

    /// <summary>
    /// 
    /// </summary>
    public DbSet<ProductGroup> ProductGroups { get; }
}