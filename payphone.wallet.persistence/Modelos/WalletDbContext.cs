using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace payphone.wallet.persistence.Modelos;

public partial class WalletDbContext : DbContext
{
    
    public WalletDbContext(DbContextOptions<WalletDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserW> UserWs { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletMovement> WalletMovements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserW>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.State).IsFixedLength();

            entity.HasOne(d => d.UserCreateNavigation).WithMany(p => p.WalletUserCreateNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserW_Wallet");

            entity.HasOne(d => d.UserUpdateNavigation).WithMany(p => p.WalletUserUpdateNavigations).HasConstraintName("FK_UserWu_Wallet");
        });

        modelBuilder.Entity<WalletMovement>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Type).IsFixedLength();

            entity.HasOne(d => d.UserCreateNavigation).WithMany(p => p.WalletMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserW_WalletMovement");

            entity.HasOne(d => d.Wallet).WithMany(p => p.WalletMovements)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_WalletMovement");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
