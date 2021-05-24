namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cafés
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cafés()
        {
            DetallesOrdenCafés = new HashSet<DetallesOrdenCafés>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDcafé { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int IDtamaño { get; set; }

        public virtual Tamaños Tamaños { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesOrdenCafés> DetallesOrdenCafés { get; set; }
    }
}
