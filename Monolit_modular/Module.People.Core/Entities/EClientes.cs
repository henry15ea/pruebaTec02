using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.People.Core.Entities
{
    [Table("Clientes")]
    public class EClientes
    {
        [Key]  // Marca "ClienteID" como la clave primaria
        [Column("clienteid")]
        public int clienteid { get; set; }

        [ForeignKey("Usuario")]  // Marca la propiedad "UsuarioID" como clave foránea a "Usuarios"
        [Column("usuarioid")]
        public int usuarioid { get; set; }

        [Column("nombre")]
        [StringLength(100)]  // Limita la longitud del nombre a 100 caracteres
        public string nombre { get; set; }

        [Column("apellido")]
        [StringLength(100)]  // Limita la longitud del apellido a 100 caracteres
        public string apellido { get; set; }

        [Column("fechanacimiento")]
        public DateTime fechanacimiento { get; set; }

        [Column("direccion")]
        [StringLength(200)]  // Limita la longitud de la dirección a 200 caracteres
        public string direccion { get; set; }

        [Column("telefono")]
        [StringLength(20)]  // Limita la longitud del teléfono a 20 caracteres
        public string telefono { get; set; }

        [Column("correo")]
        [StringLength(100)]  // Limita la longitud del correo a 100 caracteres
        public string correo { get; set; }

        // Relación con la entidad Usuario (cada Cliente está relacionado con un Usuario)
        public virtual EUsuarios Usuario { get; set; }
        //end user functions or definitions
    }

    //end class
}
//end namespaces
