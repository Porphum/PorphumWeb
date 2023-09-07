using General.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumSales.Logic.Abstractions.Storage;

public interface IRepositoryContext : IBaseRepositoryContext
{
    public DbSet<DocumentsRow> DocumentsRows { get; }

    public DbSet<Document> Documents { get; }

    public DbSet<DocumentConfig> Configs { get; }
}
