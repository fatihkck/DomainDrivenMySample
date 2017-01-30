using System;

namespace ApplicationServices.Model
{
    public class ServiceResponseBase
    {
        public ServiceResponseBase()
        {
            Exception = null;
        }

        public Exception Exception { get; set; }
    }
}
