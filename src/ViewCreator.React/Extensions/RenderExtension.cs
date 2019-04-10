namespace ViewCreator.Extensions
{
    using global::React;
    using global::React.AspNet;
    using JavaScriptEngineSwitcher.ChakraCore;
    using JavaScriptEngineSwitcher.Core;
    using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using MvcTool;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using ViewCreator.Mvc;
    using ViewCreator.React;
    using ViewCreator.React.Rendering;
    using ViewCreator.Rendering;

    public static class RenderExtensions
    {
        public static IReactViewBuilder AddReactViewCreator(this IServiceCollection services)
        {
            return AddReactViewCreator(services, null);
        }

        public static IReactViewBuilder AddReactViewCreator(this IServiceCollection services, IJsEngineSwitcher engineSwitcher)
        {
            return AddReactViewCreator(services, engineSwitcher, (options) => options.DefaultEngineName = ChakraCoreJsEngine.EngineName);
        }

        public static IReactViewBuilder AddReactViewCreator(this IServiceCollection services, IJsEngineSwitcher engineSwitcher, Action<IJsEngineSwitcher> configure)
        {
            return AddReactViewCreator(services, engineSwitcher,
                (options) => options.DefaultEngineName = ChakraCoreJsEngine.EngineName,
                (collection) => collection.AddChakraCore());
        }

        public static IReactViewBuilder AddReactViewCreator(this IServiceCollection services, IJsEngineSwitcher engineSwitcher, Action<IJsEngineSwitcher> configure, Action<JsEngineFactoryCollection> jsEngineFactoryCollectionAction)
        {
            services.AddReact();

            var jsEngineFactoryCollection = engineSwitcher != null ?
                services.AddJsEngineSwitcher(engineSwitcher, configure) :
                services.AddJsEngineSwitcher(configure);

            jsEngineFactoryCollectionAction?.Invoke(jsEngineFactoryCollection);

            ReactViewBuilder reactBuilder = new ReactViewBuilder();

            services.AddSingleton<IViewBuilder>(reactBuilder);
            services.AddSingleton<ViewBuilderConfig>(reactBuilder.ViewBuilderConfig);
            services.AddSingleton<IViewCreatorExtension, ReactViewCreatorExtension>();

            services.AddStaticHttpContextAccessor();
            services.AddStaticSessionScopeFactory();

            return reactBuilder;
        }

        public static void UseReactViewCreator(this IApplicationBuilder applicationBuilder, BabelFileOptions fileOptions = null)
        {
            UseReactViewCreator(applicationBuilder, (config) => { }, fileOptions);
        }

        /// <summary>
        /// app.UseMvc();
        /// app.UseStaticFiles();
        /// 
        /// Kodlarının altında olmalıdır.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void UseReactViewCreator(this IApplicationBuilder applicationBuilder, Action<IReactSiteConfiguration> configure, BabelFileOptions fileOptions = null)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;

            ReactViewBuilder reactBuilder = serviceProvider.GetService<IViewBuilder>() as ReactViewBuilder;

            applicationBuilder.UseReact(config =>
            {
                config.AddScript(reactBuilder.ReactViewBuilderConfig.ReactFilePath);

                configure?.Invoke(config);

            }, fileOptions);

            foreach (var componentRegister in reactBuilder.ComponentRegisters)
            {
                componentRegister.Register(reactBuilder);
            }

            applicationBuilder.UseStaticHttpContextAccessor();
            applicationBuilder.UseStaticSessionScopeFactory();

            StringBuilder stringBuilder = reactBuilder.GenerateBuilderFile(serviceProvider);

            Task.WaitAll(
                SaveReactBuilderFile(stringBuilder, serviceProvider.GetService<IHostingEnvironment>(), reactBuilder.ReactViewBuilderConfig));
        }

        private static async Task SaveReactBuilderFile(StringBuilder stringBuilder, IHostingEnvironment env, ReactViewBuilderConfig config)
        {
            var path = Path.Combine(env.WebRootPath, config.ReactFilePath);
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(stringBuilder.ToString())))
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ms.CopyToAsync(fileStream);
                }
            }
        }
    }
}