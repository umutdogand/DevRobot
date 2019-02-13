namespace ViewCreator.Test
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.Features;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Extensions;

    public class TestApp : IApplicationBuilder
    {
        public IServiceProvider ApplicationServices { get; set; }

        public IFeatureCollection ServerFeatures { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        public RequestDelegate Build()
        {
            throw new NotImplementedException();
        }

        public IApplicationBuilder New()
        {
            return this;
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            return this;
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            IViewBuilder renderBuilder = services.AddReact()
                                            .SetReactFileUrl("/react-render.js")
                                            .SetMinify(true);

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            TestApp testApp = new TestApp();
            testApp.ApplicationServices = serviceProvider;
            testApp.UseReact();

            renderBuilder.AddAssembly(typeof(Program).Assembly);
            StringBuilder stringBuilder = renderBuilder.Render(serviceProvider);

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}