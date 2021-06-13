namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permisos_Usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int IDpermiso { get; set; }

        public int IDusuario { get; set; }

        public virtual Permisos Permisos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
