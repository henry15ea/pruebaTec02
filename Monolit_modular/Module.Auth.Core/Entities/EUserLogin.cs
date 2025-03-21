﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Module.Auth.Core.Entities
{
    //[Table("Usuarios")]  // Mapea la clase a la tabla "Usuarios"
    public class EUserLogin
    {
        [Key]  // Define la propiedad como clave primaria
        [Column("usuarioid")]  // Mapea la propiedad a la columna "UsuarioID"
        public int usuarioid { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombreusuario")]  // Mapea la propiedad a la columna "NombreUsuario"
        public string nombreusuario { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("contrasena")]  // Mapea la propiedad a la columna "Contrasena"
        public string contrasena { get; set; }

        [MaxLength(100)]
        [Column("nombrecompleto")]  // Mapea la propiedad a la columna "NombreCompleto"
        public string nombrecompleto { get; set; }

        [MaxLength(100)]
        [Column("correo")]  // Mapea la propiedad a la columna "Correo"
        public string correo { get; set; }

        [Column("fecharegistro")]  // Mapea la propiedad a la columna "FechaRegistro"
        public DateTime fecharegistro { get; set; }

        [Column("estado")]  // Mapea la propiedad a la columna "Estado"
        public bool estado { get; set; }
    }

    //end class
}
//end namespaces
