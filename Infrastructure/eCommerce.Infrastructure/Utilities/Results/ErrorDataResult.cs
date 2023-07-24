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
        public ErrorDataResult(T data, List<string> errors) : base(data, false)
        {
            Errors = errors;
        }
        public ErrorDataResult(List<string> errors) : base(false)
        {
            Errors = errors;
        }
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(false, message)
        {

        }
        public List<string> Errors { get; }
    }
}
