using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_WebApp_Core.Models
{
    public class CustomMiddleware
    {
        RequestDelegate _next;
       public CustomMiddleware(RequestDelegate next)
        {
            this._next = next;

        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("My custom Middleware class");
            await _next.Invoke(context);
        }

    }
    public static class ExtensionMethod
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
