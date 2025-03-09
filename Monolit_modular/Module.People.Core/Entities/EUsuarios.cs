using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.People.Core.Entities
{
    public class EUsuarios
    {
        [Key]
        [Column("usuarioid")]
        public int usuarioid { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombreusuario")]
        public string nombreusuario { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("contrasena")]
        public string contrasena { get; set; }

        [MaxLength(100)]
        [Column("nombrecompleto")]
        public string nombrecompleto { get; set; }

        [MaxLength(100)]
        [Column("correo")]
        public string correo { get; set; }

        [Column("fecharegistro")]
        public DateTime fecharegistro { get; set; }

        [Column("estado")]
        public bool estado { get; set; }

        // Esta propiedad ya no es necesaria
        // public EUsuarios Cliente { get; set; }
    }
}
