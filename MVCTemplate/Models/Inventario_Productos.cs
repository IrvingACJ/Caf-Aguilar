namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inventario_Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventario_Productos()
        {
            Ventas_Inventario = new HashSet<Ventas_Inventario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDproducto { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

        public int? Minimo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas_Inventario> Ventas_Inventario { get; set; }
    }
}
