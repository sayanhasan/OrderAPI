using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Application
{
    public class ServiceResponse<T> where T : class
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
        public string Message { get; set; }
        public T Response { get; set; }
    }
}
