using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Filters
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            StringValues value = new StringValues();
            var userId = context.Request.Headers.TryGetValue("UserId",out value);
            if(userId)
            {
                await context.Response.WriteAsync(value);
                await _next.Invoke(context);
            }
            else
            {//Lucene
               
                await _next.Invoke(context);

            }
            
        }
    }
}
