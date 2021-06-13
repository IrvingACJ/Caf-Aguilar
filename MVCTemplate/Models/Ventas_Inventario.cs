namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ventas_Inventario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDproducto { get; set; }

        public int? IDcafé { get; set; }

        public int? IDpostre { get; set; }

        public virtual Cafés Cafés { get; set; }

        public virtual Inventario_Productos Inventario_Productos { get; set; }

        public virtual Postres Postres { get; set; }
    }
}
