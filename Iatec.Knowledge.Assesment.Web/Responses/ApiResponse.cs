using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iatec.Knowledge.Assesment.Web.Responses
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

       
        public ApiResponse(T data)
        {
            Data = data;
        }
        public ApiResponse()
        {

        }

    }
}