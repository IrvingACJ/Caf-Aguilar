namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ordenes_View
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Orden { get; set; }

        public DateTime? Fecha { get; set; }

        [Column("Cantidad Productos")]
        public int? Cantidad_Productos { get; set; }

        [Column("Monto Total", TypeName = "money")]
        public decimal? Monto_Total { get; set; }
    }
}
