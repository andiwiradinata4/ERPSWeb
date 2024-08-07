using System.Numerics;

namespace ERPS.Core.Response.v1
{
    public class AppResponse
    {
        public BigInteger Count {  get; set; }
        public BigInteger TotalPage {  get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public AppResponse(bool success, string message, BigInteger count, BigInteger totalPage, object? data)
        {
            Success = success;
            Message = message;
            Count = count;
            TotalPage = totalPage;
            Data = data;
        }

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
