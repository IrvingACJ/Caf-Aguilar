namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductoInventario_view
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDproducto { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public int? Cantidad { get; set; }

        public int? Minimo { get; set; }
    }
}
