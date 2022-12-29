using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Recetario.Models;

public partial class BdrecetasContext : DbContext
{
    public BdrecetasContext()
    {
    }

    public BdrecetasContext(DbContextOptions<BdrecetasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Unidade> Unidades { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SELIN-LGONZALEZ;Database=BDRecetas;User Id=larryGonzalez;Password=ci11159753;Encrypt=False");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07EAF9FFBD");

            entity.Property(e => e.Concepto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngrediente).HasName("PK__Ingredie__3DA4DD60C8D1AE26");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRecetasNavigation).WithMany(p => p.Ingredientes)
                .HasForeignKey(d => d.IdRecetas)
                .HasConstraintName("FK_IdRecetario");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.Ingredientes)
                .HasForeignKey(d => d.IdUnidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_IdUnidad");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.IdRecetas).HasName("PK__Recetas__042B26DF7F35251B");

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Origen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Preparacion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("PK__Unidades__437725E66BF84986");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
