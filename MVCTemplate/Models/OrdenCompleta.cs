namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdenCompleta")]
    public partial class OrdenCompleta
    {
        [Key]
        public long ID_COL { get; set; }

        public int? IDorden { get; set; }

        public int? IDproduct { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(4)]
        public string Tipo { get; set; }
    }
}
