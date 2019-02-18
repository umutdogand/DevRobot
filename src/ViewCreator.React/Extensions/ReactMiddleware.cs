namespace ViewCreator.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public class ReactMiddleware
    {
        private readonly RequestDelegate _next;

        public ReactMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            /*
             *  Eğer react.js isteği gelirse component dosyasını gönder
             * 
             */

            await _next(context);
        }
    }
}