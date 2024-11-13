using Azure;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace EGM.AracKiralama.API.Middlewares
{
    public class FirstMiddleware
    {
        private RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("1.Middleware çalıştı.");
            await _next.Invoke(httpContext);
            Console.WriteLine("1.Middleware sona erdi.");
        }
    }
}
