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

        void AddOrUpdateComponent<T1, T2>() where T1 : IHtmlComponent where T2 : IRender;

        void AddAssembly(Assembly assembly);

        StringBuilder Render(IServiceProvider provider);
    }
}