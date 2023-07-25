using eCommerce.Application.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(List<string> errors,int statusCode) : base(false,statusCode)
        {
            Errors = errors;
        }
        public ErrorDataResult(T data, string message, int statusCode) : base(data, false, message, statusCode)
        {

        }
        public ErrorDataResult(T data, int statusCode) : base(data, false, statusCode)
        {

        }
        public ErrorDataResult(string message, int statusCode) : base(false, message, statusCode)
        {

        }
        public List<string> Errors { get; }
    }
}
