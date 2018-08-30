using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace KanbanAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class KanbanExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public KanbanExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //Log.Information($"MiddleWare : {httpContext.Action")
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class KanbanExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseKanbanExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<KanbanExceptionMiddleware>();
        }
    }
}
