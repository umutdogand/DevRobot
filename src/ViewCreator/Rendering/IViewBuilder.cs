namespace ViewCreator.Rendering
{
    using System;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;

    public interface IViewBuilder
    {
        IHtmlComponentRender FindRender(IHtmlComponent component);

        StringBuilder Render(IServiceProvider provider);
    }

    public interface IViewBuilder<T> : IViewBuilder where T : IViewBuilder 
    {
        T AddOrUpdateComponent<T1, T2>() where T1 : IHtmlComponent where T2 : IHtmlComponentRender;

        T AddAssembly(Assembly assembly);

        T AddType(Type type);

        T AddComponentRegister(IComponentRegister componentRegister);

        T SetConfig(Action<ViewBuilderConfig> action);
    }
}