namespace ViewCreator.TestMvc
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.React;
    using ViewCreator.Extensions;
    using MvcTool.Helper;
    using MvcTool;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddStaticSessionScopeFactory();
            services.AddStaticHttpContextAccessor();

            services.AddSession();

            services.AddReactViewCreator()
                .AddLayoutModelsFromAssembly(typeof(Program).Assembly)
                .AddComponentRegister(new ReactComponentRegister())
                .SetConfig(config => { config.MinifyEnabled = true; });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseStaticSessionScopeFactory();
            app.UseStaticHttpContextAccessor();

            app.UseSession(new SessionOptions());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseReactViewCreator();
        }
    }
}