using eCommerce.Application.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success, string message,int statusCode) :base(success, message)
        {
            Data = data;
            StatusCode = statusCode;
        }
        public DataResult(T data, bool success,int statusCode) : base(success)
        {
            Data = data;
            StatusCode = statusCode;
        }
        public DataResult(bool success, string message, int statusCode) : base(success, message)
        {
            StatusCode = statusCode;
        }
        public DataResult(bool success,int statusCode) : base(success)
        {
            StatusCode = statusCode;
        }
        public T Data { get; }
        public int StatusCode { get; set; }
    }
}
