﻿namespace ViewCreator.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using MvcTool;
    using MvcTool.Helper;
    using System.IO;
    using System.Threading.Tasks;
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
            if (context == null)
            {
                throw new System.ArgumentNullException(nameof(context));
            }

            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var provider = scope.ServiceProvider;
                if (provider.GetService<ViewBuilderConfig>() is ReactViewBuilderConfig viewBuilderConfig &&
                    provider.GetService<IViewBuilder>() is IReactViewBuilder reactViewBuilder)
                {
                    var path = context.Request.Path;
                    if (path == Path.Combine("\\", viewBuilderConfig.ReactFilePath))
                    {
                        await context.WriteResultAsync(new ObjectResult(reactViewBuilder.GenerateBuilderFile(provider).ToString()));
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}