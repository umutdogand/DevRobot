namespace MvcTool
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class StaticSessionScopeFactoryExtensions
    {
        public static void AddStaticSessionScopeFactory(this IServiceCollection services)
        {
        }

        public static IApplicationBuilder UseStaticSessionScopeFactory(this IApplicationBuilder app)
        {
            var factory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            Helper.SessionScopeFactory.Configure(factory);
            return app;
        }
    }
}