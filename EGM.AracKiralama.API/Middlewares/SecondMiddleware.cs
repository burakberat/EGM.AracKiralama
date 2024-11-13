using Azure;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace EGM.AracKiralama.API.Middlewares
{
    public class SecondMiddleware
    {
        private RequestDelegate _next;

        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("2.Middleware çalıştı.");
            await _next.Invoke(httpContext);
            Console.WriteLine("2.Middleware sona erdi.");
        }
    }
}
