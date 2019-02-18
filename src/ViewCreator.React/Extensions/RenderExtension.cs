namespace ViewCreator.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.Helper;
    using ViewCreator.React.Rendering;
    using ViewCreator.Rendering;

    public static class RenderExtensions
    {
        public static IReactViewBuilder AddReact(this IServiceCollection services)
        {
            ReactViewBuilder reactBuilder = new ReactViewBuilder();

            services.AddSingleton<IViewBuilder>(reactBuilder);
            services.AddSingleton<ViewBuilderConfig>(reactBuilder.ViewBuilderConfig);

            services.AddStaticHttpContextAccessor();
            services.AddStaticSessionScopeFactory();

            return reactBuilder;
        }

        public static void UseReact(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;

            ReactViewBuilder reactBuilder = serviceProvider.GetService<IViewBuilder>() as ReactViewBuilder;

            foreach (var componentRegister in reactBuilder.ComponentRegisters)
            {
                componentRegister.Register(reactBuilder);
            }

            applicationBuilder.UseStaticHttpContext();
            applicationBuilder.UseStaticSessionScopeFactory();

            applicationBuilder.UseMiddleware<ReactMiddleware>();
        }
    }
}