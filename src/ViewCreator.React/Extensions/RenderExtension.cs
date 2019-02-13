namespace ViewCreator.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.ServiceModel.Channels;
    using System.Threading.Tasks;
    using ViewCreator.Components;
    using ViewCreator.React;

    public static class RenderExtensions
    {
        public static IReactBuilder AddReact(this IServiceCollection services)
        {
            ReactBuilder reactBuilder = new ReactBuilder();

            /*
             * React ile ilgili render sınıflarının inject edildiği fonksiyon
             * 
             */

            services.AddSingleton<IViewBuilder>(reactBuilder);

            return reactBuilder;
        }

        public static void UseReact(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;

            ReactBuilder reactBuilder = serviceProvider.GetService<IViewBuilder>() as ReactBuilder;

            reactBuilder.AddOrUpdateComponent<ButtonAttribute, ButtonReactRender>();
            reactBuilder.AddOrUpdateComponent<LinearLayoutAttribute, LinearLayoutReactRender>();
            reactBuilder.AddOrUpdateComponent<LabelAttribute, LabelReactRender>();

            applicationBuilder.UseMiddleware<ReactMiddleware>();
        }
    }

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