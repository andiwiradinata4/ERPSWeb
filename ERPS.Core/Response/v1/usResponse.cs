using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPS.Core.Response.v1
{
    public class AppResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public AppResponse(bool success, string message, object? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public AppResponse(bool success, Exception? exception, object? data)
        {
            Success = success;
            Message = exception == null ? "Error Not Define" : exception.Message;
            Data = data;
        }
    }
}
