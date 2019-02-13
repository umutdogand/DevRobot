namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Rendering;

    public interface IViewBuilder
    {
        IRender FindRender(IHtmlComponent component);

        IViewBuilder AddOrUpdateComponent<T1, T2>() where T1 : IHtmlComponent where T2 : IRender;

        IViewBuilder AddAssembly(Assembly assembly);

        IViewBuilder SetMinify(bool minify);

        StringBuilder Render(IServiceProvider provider);

        StringBuilder Rendering(IServiceProvider provider);
    }
}