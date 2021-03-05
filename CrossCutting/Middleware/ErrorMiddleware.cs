using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                object result;

                if(error is GlobalException)
                {
                    GlobalException globalError = error as GlobalException;
                    response.StatusCode = (int)globalError.StatusCode;
                    result = new { Code = globalError.Code, Message = error.Message, Detail = globalError.StackTrace, Object = globalError.Object };
                }
                else
                {
                    response.StatusCode = 500;
                    result = new { Code = 0, Message = error.Message, Detail = error.StackTrace, Object = string.Empty };
                }

                string resultJson = JsonConvert.SerializeObject(result);
                await response.WriteAsync(resultJson);
            }
        }
    }

    public class GlobalException: Exception
    {
        public readonly int Code;
        public readonly HttpStatusCode StatusCode;
        public readonly object Object;

        public GlobalException(HttpStatusCode statusCode): base()
        {
            StatusCode = statusCode;
        }

        public GlobalException(HttpStatusCode statusCode, int code): base()
        {
            StatusCode = statusCode;
            Code = code;
        }

        public GlobalException(HttpStatusCode statusCode, string message): base(message)
        {
            StatusCode = statusCode;
        }

        public GlobalException(HttpStatusCode statusCode, int code, string message): base(message)
        {
            Code = code;
            StatusCode = statusCode;
        }

        public GlobalException(HttpStatusCode statusCode, string message, Exception innerException): base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public GlobalException(HttpStatusCode statusCode, int code, string message, Exception innerException): base(message, innerException)
        {
            Code = code;
            StatusCode = statusCode;
        }

        public GlobalException(HttpStatusCode statusCode, object errorObject) : base()
        {
            StatusCode = statusCode;
            Object = errorObject;
        }

    }
}