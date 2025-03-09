using System;

namespace Module.People.Core.DTO.AccountDetails
{
    public class AccountBalance
    {
        public string tipocuenta { get; set; }
        public DateTime fechaapertura { get; set; }
        public string codigocuenta { get; set; }

        public decimal Saldo { get; set; }
        //end user functions or definitions 
    }

    //end class
}
//end namespaces
