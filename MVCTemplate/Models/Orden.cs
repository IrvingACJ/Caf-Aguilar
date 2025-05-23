namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orden")]
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            DetallesOrdenCafés = new HashSet<DetallesOrdenCafés>();
            DetallesOrdenPostres = new HashSet<DetallesOrdenPostres>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDorden { get; set; }

        public DateTime? Fecha { get; set; }

        [Column(TypeName = "money")]
        public decimal? postres { get; set; }

        [Column(TypeName = "money")]
        public decimal? cafés { get; set; }

        [Column(TypeName = "money")]
        public decimal? extras { get; set; }

        [Column(TypeName = "money")]
        public decimal? total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesOrdenCafés> DetallesOrdenCafés { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesOrdenPostres> DetallesOrdenPostres { get; set; }
    }
}
