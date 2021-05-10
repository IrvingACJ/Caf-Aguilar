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
        public virtual DbSet<DetallesOrden> DetallesOrden { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Postres> Postres { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ordenes_View> Ordenes_View { get; set; }
        public virtual DbSet<PowerDusuarios> PowerDusuarios { get; set; }
        public virtual DbSet<ProductoInventario_view> ProductoInventario_view { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cafés>()
                .Property(e => e.IDcafé)
                .IsUnicode(false);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Regular)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Grande)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Rocas)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cafés>()
                .Property(e => e.Frappe)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DetallesOrden>()
                .Property(e => e.IDcafépostres)
                .IsUnicode(false);

            modelBuilder.Entity<DetallesOrden>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

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
                .Property(e => e.IDpostre)
                .IsUnicode(false);

            modelBuilder.Entity<Postres>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Postres>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenes_View>()
                .Property(e => e.Monto_Total)
                .HasPrecision(19, 4);

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
