using System.IO;
using System.Threading.Tasks;

namespace WebApplication1.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var log = $"{DateTime.Now}: {context.Request.Path} | User: {context.User.Identity?.Name ?? "Anonymous"}";
            Console.WriteLine(log);

            await File.AppendAllTextAsync("request_log.txt", log + Environment.NewLine);

            await _next(context);
        }
    }
}
