using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.People.Core.Entities
{
    //[Table("cuentas", Schema = "public")]
    public class EUserAccount
    {
        [Key]
        [Column("cuentaid")]
        public int cuentaid { get; set; }

        [ForeignKey("Cliente")]
        [Column("clienteid")]
        public int? clienteid { get; set; }  

        [Column("tipocuenta")]
        [StringLength(20)]
        public string tipocuenta { get; set; }

        [Column("saldo")]
        [DataType("decimal(18,2)")]
        public decimal? saldo { get; set; } 

        [Column("fechaapertura")]
        public DateTime? fechaapertura { get; set; } 

        [Column("codigocuenta")]
        [StringLength(20)]
        public string codigocuenta { get; set; }

        // Navegación de clave foránea (si deseas acceso a la entidad Cliente)
        public virtual EClientes Cliente { get; set; }
        //end user functions or definitions
    }
    //end class
}
//end namespaces