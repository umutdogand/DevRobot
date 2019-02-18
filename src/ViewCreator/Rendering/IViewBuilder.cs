namespace ViewCreator.Rendering
{
    using System;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;

    public interface IViewBuilder
    {
        IRender FindRender(IComponent component);

        IRender FindRender(Type componentType);

        StringBuilder GenerateReactBuilderFile(IServiceProvider provider);
    }

    public interface IViewBuilder<T> : IViewBuilder where T : IViewBuilder
    {
        T AddOrUpdateComponent<T1, T2>() where T1 : IComponent where T2 : IRender;

        T AddAssembly(Assembly assembly);

        T AddType(Type type);

        T AddComponentRegister(IComponentRegister componentRegister);

        T SetConfig(Action<ViewBuilderConfig> action);
    }
}