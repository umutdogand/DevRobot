namespace ViewCreator.React.Rendering
{
    using System;
    using ViewCreator.Rendering;

    public interface IReactViewBuilder : IViewBuilder<IReactViewBuilder>
    {
        IReactViewBuilder SetConfig(Action<ReactViewBuilderConfig> action);
    }
}