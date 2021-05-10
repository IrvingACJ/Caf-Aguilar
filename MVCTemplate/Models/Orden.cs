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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDorden { get; set; }

        public DateTime? Fecha { get; set; }

        [Column(TypeName = "money")]
        public decimal? total { get; set; }
    }
}
