using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.DTOs {
    public class GenericResponse<T> where T : class{

        public HttpStatusCode httpCode { get; set; } 
        public T? returnData { get; set; }
        public ExpandoObject? returnError { get; set; }

    }
}
