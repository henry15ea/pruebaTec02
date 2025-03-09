namespace Module.People.Core.DTO.MoneyTransfer
{
    public class TransactionUpdateDTO
    {
        public string CodigoCuentaOrigen { get; set; }
        public string CodigoCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        //end user functions or definitions
    }

    //end class
}
//end namespaces
