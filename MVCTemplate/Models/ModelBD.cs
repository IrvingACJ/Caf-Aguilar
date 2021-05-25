using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCTemplate.Models
{
    public partial class ModelBD : DbContext
    {
        public ModelBD()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Cafés> Cafés { get; set; }
        public virtual DbSet<DetallesOrdenCafés> DetallesOrdenCafés { get; set; }
        public virtual DbSet<DetallesOrdenPostres> DetallesOrdenPostres { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Postres> Postres { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Tamaños> Tamaños { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<PowerDusuarios> PowerDusuarios { get; set; }
        public virtual DbSet<ProductoInventario_view> ProductoInventario_view { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cafés>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DetallesOrdenCafés>()
                .Property(e => e.Extras)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orden>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.P1)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.P2)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.P3)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.P4)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.P5)
                .IsUnicode(false);

            modelBuilder.Entity<Postres>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Postres>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Postres>()
                .HasMany(e => e.DetallesOrdenPostres)
                .WithOptional(e => e.Postres)
                .HasForeignKey(e => e.IDpostres);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .HasOptional(e => e.Inventario)
                .WithRequired(e => e.Productos);

            modelBuilder.Entity<Tamaños>()
                .Property(e => e.Tamaño)
                .IsUnicode(false);

            modelBuilder.Entity<Tamaños>()
                .HasMany(e => e.Cafés)
                .WithRequired(e => e.Tamaños)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipos>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipos>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasOptional(e => e.Permisos)
                .WithRequired(e => e.Usuarios);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.P1)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.P2)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.P3)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.P4)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuarios>()
                .Property(e => e.P5)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoInventario_view>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ProductoInventario_view>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);
        }
    }
}
