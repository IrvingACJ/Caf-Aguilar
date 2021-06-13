namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Postres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postres()
        {
            DetallesOrdenPostres = new HashSet<DetallesOrdenPostres>();
            Ventas_Inventario = new HashSet<Ventas_Inventario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDpostre { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesOrdenPostres> DetallesOrdenPostres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas_Inventario> Ventas_Inventario { get; set; }
    }
}
