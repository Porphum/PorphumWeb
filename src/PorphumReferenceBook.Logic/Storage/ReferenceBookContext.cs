using Microsoft.EntityFrameworkCore;
using PorphumReferenceBook.Logic.Storage.Models;

namespace PorphumReferenceBook.Logic.Storage;

/// <summary xml:lang="ru">
/// Контекст базы данных справочника.
/// </summary>
public sealed class ReferenceBookContext : DbContext
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="ReferenceBookContext"/>.
    /// </summary>
    /// <param name="optionsBuilder">Параметры для контекста.</param>
    public ReferenceBookContext(DbContextOptions<ReferenceBookContext> optionsBuilder)
        : base(optionsBuilder)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    /// <summary xml:lang="ru">
    /// Продукты.
    /// </summary>
    public DbSet<Product> Products { get; set; } = default!;

    /// <summary xml:lang="ru">
    /// Клиенты.
    /// </summary>
    public DbSet<Client> Clients { get; set; } = default!;

    /// <summary xml:lang="ru">
    /// Группы продуктов.
    /// </summary>
    public DbSet<ProductGroup> ProductsGroups { get; set; } = default!;

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

            entity.Property(e => e.Address)
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

            //entity.Property(e => e.ParentId).HasColumnName("parent_id");
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
