using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.People.Core.Entities
{
    [Table("transacciones")]
    public class ETransacciones
    {
        [Key]
        [Column("transaccionid")]
        public int transaccionid { get; set; }

        // Relación con la cuenta de origen
        [ForeignKey("CuentaOrigen")]
        [Column("cuentaorigenid")]
        public int? cuentaorigenid { get; set; }

        // Relación con la cuenta de destino
        [ForeignKey("CuentaDestino")]
        [Column("cuentadestinoid")]
        public int? cuentadestinoid { get; set; }

        [Column("monto")]
        [DataType("decimal(18,2)")]
        public decimal monto { get; set; }

        [Column("fechatransaccion")]
        public DateTime fechatransaccion { get; set; } = DateTime.Now; // Valor por defecto como CURRENT_TIMESTAMP en SQL

        [Column("tipotransaccion")]
        [StringLength(20)]
        public string TipoTransatipotransaccionccion { get; set; }

        [Column("descripcion")]
        [StringLength(255)]
        public string descripcion { get; set; }
        
        [Column("codigotransaccion")]
        [StringLength(255)]
        public string codigotransaccion { get; set; }

        
        public EUserAccount cuentaorigen { get; set; }
        public EUserAccount cuentadestino { get; set; }

        //end user functions or definitions
    }

    //end class
}
//end namespaces
