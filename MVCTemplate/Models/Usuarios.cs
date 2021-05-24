namespace MVCTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDusuario { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Contraseña { get; set; }

        public virtual Permisos Permisos { get; set; }
    }
}
