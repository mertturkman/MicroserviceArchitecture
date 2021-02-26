using System;
using System.Collections.Generic;
using System.Text;

namespace Middleware.CustomException
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
