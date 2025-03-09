namespace Module.People.Core.DTO.common
{
    public class ResponseWrapper<T>
    {
        public T Data { get; set; }
        public StatusResponse StatusResponse { get; set; } = new StatusResponse();
        //end user functions or definitions 
    }
    //end class
}
//end namespaces
