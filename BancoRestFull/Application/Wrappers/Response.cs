using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    { public bool Success { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }   
        public Response() { }

        public Response(T data , string message=null) {


            Success = true;
            Message = message;
            this.Data = data;
            
        
        
        }

        public Response(string message )
        {


            Success = true;
            Message = message;
            



        }

    }
}
