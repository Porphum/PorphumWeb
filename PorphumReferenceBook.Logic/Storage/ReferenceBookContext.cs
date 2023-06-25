using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PorphumReferenceBook.Logic.Abstractions.Storage;
using PorphumReferenceBook.Logic.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorphumReferenceBook.Logic.Storage;

public sealed class ReferenceBookContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<Client> Clients { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.HasKey(e => e.ClientId)
                .HasName("clients_info_pkey");

            entity.ToTable("clients_info");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");

            entity.Property(e => e.Adress)
                .HasMaxLength(80)
                .HasColumnName("adress");

            entity.Property(e => e.Inn)
                .HasMaxLength(10)
                .HasColumnName("inn");

            entity.HasOne(d => d.Client)
                .WithOne(p => p.Info)
                .HasForeignKey<ClientInfo>(d => d.ClientId)
                .HasConstraintName("clients_info_client_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Cost)
                .HasPrecision(20, 2)
                .HasColumnName("cost");

            entity.Property(e => e.GroupId).HasColumnName("group_id");

            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");

            entity.HasOne(d => d.Group)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("products_group_id_fkey");
        });

        modelBuilder.Entity<ProductGroup>(entity =>
        {
            entity.ToTable("products_groups");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");

            entity.Property(e => e.ParentId).HasColumnName("parent_id");
        });

        modelBuilder.Entity<ProductExtraInfo>(entity =>
        {
            entity.HasKey(e => e.ProductId)
                .HasName("products_info_pkey");

            entity.ToTable("products_info");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");

            entity.Property(e => e.Barcode)
                .HasMaxLength(120)
                .HasColumnName("barcode");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.HasOne(d => d.Product)
                .WithOne(p => p.Info)
                .HasForeignKey<ProductExtraInfo>(d => d.ProductId)
                .HasConstraintName("products_info_product_id_fkey");
        });
    }
}
