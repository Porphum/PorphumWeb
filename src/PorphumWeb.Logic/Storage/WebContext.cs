using Microsoft.EntityFrameworkCore;

using PorphumWeb.Logic.Storage.Models;
using System;
using System.Data;

namespace PorphumWeb.Logic.Storage;

/// <summary xml:lang="ru">
/// Контест базы данных.
/// </summary>
public sealed class WebContext : DbContext
{
    /// <summary xml:lang="ru">
    /// Создаёт экземпляр класса <see cref="WebContext"/>.
    /// </summary>
    /// <param name="optionsBuilder" xml:lang="ru">Парметры для контекста.</param>
    public WebContext(DbContextOptions<WebContext> optionsBuilder)
        : base(optionsBuilder)
    {

    }

    /// <summary xml:lang="ru">
    /// Роли пользовтелей.
    /// </summary>
    public DbSet<Role> Roles { get; set; } = default!;

    /// <summary xml:lang="ru">
    /// Пользовтели системы.
    /// </summary>
    public DbSet<User> Users { get; set; } = default!;
    
    /// <summary>
    /// Доступные подключения.
    /// </summary>
    public DbSet<Connection> Connections { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.KeyId)
                .HasName("connections_pkey");

            entity.ToTable("connections");

            entity.Property(e => e.KeyId)
                .HasMaxLength(10)
                .HasColumnName("key_id");

            entity.Property(e => e.DbName)
                .HasMaxLength(20)
                .HasColumnName("db_name");

            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Login)
                .HasMaxLength(60)
                .HasColumnName("login");

            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");

            entity.HasMany(d => d.Roles)
                .WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRolesMap",
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("user_roles_map_role_id_fkey"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("user_roles_map_user_id_fkey"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("user_roles_map_pkey");

                        j.ToTable("user_roles_map");

                        j.IndexerProperty<long>("UserId").HasColumnName("user_id");

                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });
    }
}
