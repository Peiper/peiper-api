using System;

namespace PeiperApi.Domain.Models
{
    public class Response<T>
    {
        public T Result { get; set; }
        public Exception Exception { get; set; }

        public Response()
        {
            
        }
        public Response(T value)
        {
            Result = value;
        }
    }
}
