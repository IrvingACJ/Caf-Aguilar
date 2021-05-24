namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetallesOrdenPostres
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDorden { get; set; }

        public int? IDpostres { get; set; }

        public int? Cantidad { get; set; }

        public virtual Orden Orden { get; set; }

        public virtual Postres Postres { get; set; }
    }
}
