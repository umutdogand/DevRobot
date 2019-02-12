namespace ViewCreator.Test
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Extensions;

    public class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            IViewBuilder renderBuilder = services.AddReact();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            serviceProvider.UseReact();

            renderBuilder.AddAssembly(typeof(Program).Assembly);
            StringBuilder stringBuilder = renderBuilder.Render(serviceProvider);

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}