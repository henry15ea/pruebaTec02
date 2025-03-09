using System;

namespace Module.People.Core.DTO.MoneyTransfer
{
    public class ProcccessTransferStatusDTO
    {
        public string TransactionId { get; set; } 
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
        public string TipoTransaccion { get; set; }
        public string Descripccion { get; set; }
        public decimal Monto { get; set; }
        public DateTime fechaTransaccion { get; set; }
        //end user functions or definitions
    }
    //end class
}
//end namespaces
