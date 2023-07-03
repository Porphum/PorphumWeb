using Microsoft.EntityFrameworkCore;
using PorphumSales.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PorphumSales.Logic.Storage;

public sealed class SalesContext : DbContext
{
    public SalesContext(DbContextOptions<SalesContext> optionsBuilder)
        : base(optionsBuilder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Document> Documents { get; set; } = null!;

    public DbSet<DocumentsRow> DocumentsRows { get; set; } = null!;

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
    }
}
