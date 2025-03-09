using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.People.Core.Entities
{
    [Table("clientes")]
    public class EClientes
    {
        [Key]
        [Column("clienteid")]
        public int clienteid { get; set; }

        [ForeignKey("usuarioid")]
        [Column("usuarioid")]
        public int usuarioid { get; set; }

        [Column("nombre")]
        [StringLength(100)]
        public string nombre { get; set; }

        [Column("apellido")]
        [StringLength(100)]
        public string apellido { get; set; }

        [Column("fechanacimiento")]
        public DateTime fechanacimiento { get; set; }

        [Column("direccion")]
        [StringLength(200)]
        public string direccion { get; set; }

        [Column("telefono")]
        [StringLength(20)]
        public string telefono { get; set; }

        [Column("correo")]
        [StringLength(100)]
        public string correo { get; set; }

        // Relación con Usuario
        public EUsuarios Usuario { get; set; }

        // Relación con Cuentas (Un Cliente puede tener muchas Cuentas)
        public ICollection<EUserAccount> Cuentas { get; set; }
    }
}
