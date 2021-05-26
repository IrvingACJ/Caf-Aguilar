namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventario")]
    public partial class Inventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDproducto { get; set; }

        public int? Cantidad { get; set; }

        public int? Minimo { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
