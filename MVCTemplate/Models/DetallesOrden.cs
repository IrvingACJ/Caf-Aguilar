namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallesOrden")]
    public partial class DetallesOrden
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDorden { get; set; }

        [StringLength(10)]
        public string IDcafépostres { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(10)]
        public string Tipo { get; set; }
    }
}
