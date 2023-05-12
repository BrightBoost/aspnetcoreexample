using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFirstAPI.Models;

public partial class VoorbeeldApiContext : DbContext
{
    public VoorbeeldApiContext()
    {
    }

    public VoorbeeldApiContext(DbContextOptions<VoorbeeldApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductProfile> ProductProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VoorbeeldAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07C6689B3E");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<ProductProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductP__3214EC07FB3EA607");

            entity.ToTable("ProductProfile");

            entity.HasIndex(e => e.ProductId, "unique_pid").IsUnique();

            entity.Property(e => e.Img)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Link)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Product).WithOne(p => p.ProductProfile)
                .HasForeignKey<ProductProfile>(d => d.ProductId)
                .HasConstraintName("FK_ProductProfile_ToProduct");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
