using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCTemplate.Models
{
    public partial class ModelCaféAguilarDB : DbContext
    {
        public ModelCaféAguilarDB()
            : base("name=ModelCaféAguilarDB")
        {
        }

        public virtual DbSet<Cafés> Cafés { get; set; }
        public virtual DbSet<DetallesOrdenCafés> DetallesOrdenCafés { get; set; }
        public virtual DbSet<DetallesOrdenPostres> DetallesOrdenPostres { get; set; }
        public virtual DbSet<Inventario_Productos> Inventario_Productos { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenCompleta> OrdenCompleta { get; set; }

        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Permisos_Usuarios> Permisos_Usuarios { get; set; }
        public virtual DbSet<Postres> Postres { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tamaños> Tamaños { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas_Inventario> Ventas_Inventario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cafés>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Inventario_Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Inventario_Productos>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orden>()
                .Property(e => e.postres)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orden>()
                .Property(e => e.cafés)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orden>()
                .Property(e => e.extras)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orden>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Permisos>()
                .Property(e => e.Permiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permisos>()
                .HasMany(e => e.Permisos_Usuarios)
                .WithRequired(e => e.Permisos)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.Cafés)
                .WithRequired(e => e.Tipos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Permisos_Usuarios)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdenCompleta>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<OrdenCompleta>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrdenCompleta>()
                .Property(e => e.Tipo)
                .IsUnicode(false);
        }
    }
}
