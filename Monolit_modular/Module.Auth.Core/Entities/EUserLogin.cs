using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Module.Auth.Core.Entities
{
    [Table("Usuarios")]  // Mapea la clase a la tabla "Usuarios"
    public class EUserLogin
    {
        [Key]  // Define la propiedad como clave primaria
        [Column("UsuarioID")]  // Mapea la propiedad a la columna "UsuarioID"
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("NombreUsuario")]  // Mapea la propiedad a la columna "NombreUsuario"
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Contrasena")]  // Mapea la propiedad a la columna "Contrasena"
        public string Contrasena { get; set; }

        [MaxLength(100)]
        [Column("NombreCompleto")]  // Mapea la propiedad a la columna "NombreCompleto"
        public string NombreCompleto { get; set; }

        [MaxLength(100)]
        [Column("Correo")]  // Mapea la propiedad a la columna "Correo"
        public string Correo { get; set; }

        [Column("FechaRegistro")]  // Mapea la propiedad a la columna "FechaRegistro"
        public DateTime FechaRegistro { get; set; }

        [Column("Estado")]  // Mapea la propiedad a la columna "Estado"
        public bool Estado { get; set; }
    }

    //end class
}
//end namespaces
