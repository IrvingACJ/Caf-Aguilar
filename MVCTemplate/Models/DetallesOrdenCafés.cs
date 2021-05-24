namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DetallesOrdenCafés
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDorden { get; set; }

        public int? IDcafé { get; set; }

        public int? Cantidad { get; set; }

        [Column(TypeName = "money")]
        public decimal? Extras { get; set; }

        public int? IDtipo { get; set; }

        public virtual Cafés Cafés { get; set; }

        public virtual Orden Orden { get; set; }

        public virtual Tipos Tipos { get; set; }
    }
}
