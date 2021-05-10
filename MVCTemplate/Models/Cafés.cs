namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cafés
    {
        [Key]
        [StringLength(10)]
        public string IDcafé { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Regular { get; set; }

        [Column(TypeName = "money")]
        public decimal? Grande { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rocas { get; set; }

        [Column(TypeName = "money")]
        public decimal? Frappe { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
