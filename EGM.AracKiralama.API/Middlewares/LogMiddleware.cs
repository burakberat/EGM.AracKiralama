using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Entities;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace EGM.AracKiralama.API.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogService logService)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                int userId = Convert.ToInt32(context.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value);
                string requestBody = await ReadRequestBodyAsync(context.Request);

                await _next.Invoke(context);
                string responseText = await ReadResponseBodyAsync(responseBody);

                LogTable log = new LogTable()
                {
                    StatusId = 1,
                    UserId = userId,
                    RequestPath = context.Request.Path,
                    RequestBody = requestBody,
                    ResponseBody = responseText,
                    ApplicationId = 1,
                    IpAddress = context.Connection.RemoteIpAddress.ToString(),
                    LastTransactionDate = DateTime.Now,
                };
                await logService.AddLogAsync(log);

                await responseBody.CopyToAsync(originalBodyStream);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest httpRequest)
        {
            httpRequest.EnableBuffering(); // requestbody'i yeniden okumaya yarıyor.
            httpRequest.Body.Position = 0;
            using var reader = new StreamReader(httpRequest.Body, encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            httpRequest.Body.Position = 0;
            return body;
        }

        private async Task<string> ReadResponseBodyAsync(Stream responseBody)
        {
            responseBody.Position = 0;
            using var reader = new StreamReader(responseBody);
            var body = await reader.ReadToEndAsync();
            responseBody.Position = 0; //********
            return body;
        }
    }
}
