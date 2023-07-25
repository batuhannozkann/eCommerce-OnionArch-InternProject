using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
        where T : class
    {
        public SuccessDataResult(T data, string message, int statusCode) : base(data, true, message,statusCode)
        {

        }
        public SuccessDataResult(T data, int statusCode) : base(data,true,statusCode)
        {

        }
        public SuccessDataResult(string message, int statusCode) : base(true, message, statusCode)
        {

        }
    }
}
