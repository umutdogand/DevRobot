namespace ViewCreator.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;
    using ViewCreator.Helper;
    using ViewCreator.React.Rendering;
    using ViewCreator.Rendering;

    public class ReactMiddleware
    {
        private readonly RequestDelegate _next;

        public ReactMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Eğer react.js isteği gelirse component dosyasını gönder
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var provider = scope.ServiceProvider;
                if (provider.GetService<ViewBuilderConfig>() is ReactViewBuilderConfig viewBuilderConfig &&
                    provider.GetService<IViewBuilder>() is IReactViewBuilder reactViewBuilder)
                {
                    var path = context.Request.Path;
                    if (path == viewBuilderConfig.ReactFileUrl)
                    {
                        await context.WriteResultAsync(new ObjectResult(reactViewBuilder.GenerateReactBuilderFile(provider).ToString()));
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}