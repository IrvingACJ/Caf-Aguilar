namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDusuario { get; set; }

        [StringLength(1)]
        public string P1 { get; set; }

        [StringLength(1)]
        public string P2 { get; set; }

        [StringLength(1)]
        public string P3 { get; set; }

        [StringLength(1)]
        public string P4 { get; set; }

        [StringLength(1)]
        public string P5 { get; set; }
    }
}
