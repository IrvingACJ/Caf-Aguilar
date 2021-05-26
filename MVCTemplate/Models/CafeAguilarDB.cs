using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCTemplate.Models
{
    public partial class CafeAguilarDB : DbContext
    {
        public CafeAguilarDB()
            : base("name=CafeAguilarDB")
        {
        }

        public virtual DbSet<Cafés> Cafés { get; set; }
        public virtual DbSet<DetallesOrdenCafés> DetallesOrdenCafés { get; set; }
        public virtual DbSet<DetallesOrdenPostre> DetallesOrdenPostres { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Orden> Ordens { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Postre> Postres { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tamaños> Tamaños { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<PowerDusuario> PowerDusuarios { get; set; }
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

            modelBuilder.Entity<Permiso>()
                .Property(e => e.P1)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.P2)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.P3)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.P4)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.P5)
                .IsUnicode(false);

            modelBuilder.Entity<Postre>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Postre>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Postre>()
                .HasMany(e => e.DetallesOrdenPostres)
                .WithOptional(e => e.Postre)
                .HasForeignKey(e => e.IDpostres);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Producto>()
                .HasOptional(e => e.Inventario)
                .WithRequired(e => e.Producto);

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

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Permiso)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.P1)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.P2)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.P3)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
                .Property(e => e.P4)
                .IsUnicode(false);

            modelBuilder.Entity<PowerDusuario>()
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
