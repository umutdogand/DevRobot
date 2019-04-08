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

        StringBuilder GenerateBuilderFile(IServiceProvider provider);
    }

    public interface IViewBuilder<T> : IViewBuilder where T : IViewBuilder
    {
        T AddOrUpdateComponent<T1, T2>() where T1 : FeatureBase where T2 : IRender;

        T AddLayoutModelsFromAssembly(Assembly assembly);

        T AddLayoutModelType(Type type);

        T AddComponentRegister(IComponentRegister componentRegister);

        T SetConfig(Action<ViewBuilderConfig> action);
    }
}