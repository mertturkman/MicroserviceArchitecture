using System;
using System.Collections.Generic;
using System.Text;

namespace User.Application.Models
{
    public class ErrorResponseModel
    {
        public int Code { get; set; }
        public string Detail { get; set; }
        public object Object { get; set; }
    }
}
