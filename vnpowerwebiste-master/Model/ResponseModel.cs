using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Model
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class ResponseUploadModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string  Data { get; set; }
    }

}
