namespace ViewCreator.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
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

        public static void UseReact(this IServiceProvider serviceProvider)
        {
            ReactBuilder reactBuilder = serviceProvider.GetService<IViewBuilder>() as ReactBuilder;
            reactBuilder.AddOrUpdateComponent<ButtonAttribute, ButtonReactRender>();
            reactBuilder.AddOrUpdateComponent<LinearLayoutAttribute, LinearLayoutReactRender>();
            reactBuilder.AddOrUpdateComponent<LabelAttribute, LabelReactRender>();
            reactBuilder.AddOrUpdateComponent<InputAttribute, InputReactRender>();
        }
    }
}