﻿using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Storage.Models;

namespace PorphumSales.Logic.Storage;

//Scaffold-DbContext "Host=localhost;Port=5432;Database=porphum_sales;Username=postgres;Password=root" Npgsql.EntityFrameworkCore.PostgreSQL
/// <summary xml:lang="ru">
/// Контекст базы данных для документов.
/// </summary>
public sealed class SalesContext : DbContext
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="SalesContext"/>.
    /// </summary>
    /// <param name="optionsBuilder" xml:lang="ru">Параметры для контекста.</param>
    public SalesContext(DbContextOptions<SalesContext> optionsBuilder)
        : base(optionsBuilder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    /// <summary xml:lang="ru">
    /// Конфиги для документов.
    /// </summary>
    public DbSet<DocumentConfig> DocumentConfigs { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Документы.
    /// </summary>
    public DbSet<Document> Documents { get; set; } = null!;

    /// <summary xml:lang="ru">
    /// Содержания документов.
    /// </summary>
    public DbSet<DocumentsRow> DocumentsRows { get; set; } = null!;

    public DbSet<ProductCountHistory> ProductsCountHistories { get; set; } = null!;
    public DbSet<ProductPrice> ProductsPrices { get; set; } = null!;

    public DbSet<ProductStorage> ProductsStorages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("documents");

            entity.HasIndex(e => e.Number, "documents_number_key")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ClientWhoId).HasColumnName("client_who_id");

            entity.Property(e => e.ClientWithId).HasColumnName("client_with_id");

            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");

            entity.Property(e => e.Number).HasColumnName("number");

            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
        });

        modelBuilder.Entity<DocumentsRow>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.DocumentId })
                .HasName("documents_rows_pkey");

            entity.ToTable("documents_rows");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");

            entity.Property(e => e.Cost)
                .HasPrecision(20, 2)
                .HasColumnName("cost");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Document)
                .WithMany(p => p.DocumentsRows)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("documents_rows_document_id_fkey");
        });

        modelBuilder.Entity<DocumentConfig>(entity =>
        {
            entity.ToTable("document_config");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.MasterId).HasColumnName("master_id");
        });

        modelBuilder.Entity<ProductCountHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId)
                .HasName("products_count_history_pkey");

            entity.ToTable("products_count_history");

            entity.Property(e => e.HistoryId).HasColumnName("history_id");

            entity.Property(e => e.AccurDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("accur_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Delta).HasColumnName("delta");

            entity.Property(e => e.DocumentId).HasColumnName("document_id").HasDefaultValue(null).IsRequired(false);

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.WriteType)
                .HasMaxLength(10)
                .HasColumnName("write_type");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("products_count_history_document_id_fkey");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.FromDate })
                .HasName("products_prices_pkey");

            entity.ToTable("products_prices");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.FromDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("from_date")
                .HasDefaultValueSql("now()");

            entity.Property(e => e.Price)
                .HasPrecision(20, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<ProductStorage>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("products_storage");

            entity.Property(e => e.LastUpd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_upd");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.Sum).HasColumnName("sum");
        });
    }
}
