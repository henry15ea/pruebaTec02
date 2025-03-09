using System;

namespace Module.People.Core.Utils
{
    class TransactionGeneratorCode
    {

        public static string GetCodeTransaction() 
        {
            return Guid.NewGuid().ToString(); 
        }

        //end user functions or definitions
    }

    //end class
}
//end namespaces
