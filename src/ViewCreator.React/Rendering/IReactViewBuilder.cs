namespace ViewCreator.React.Rendering
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using ViewCreator.Rendering;

    public interface IReactViewBuilder : IViewBuilder<IReactViewBuilder>
    {
        ReadOnlyCollection<IReactFileFounder> ReactFileFounderList { get; }

        ReactViewBuilderConfig ReactViewBuilderConfig { get; }

        StringBuilder GeneratedBuilderFile { get; }

        IReactViewBuilder SetConfig(Action<ReactViewBuilderConfig> action);

        StringBuilder GenerateBuilderFile(IServiceProvider provider, bool force);

        IReactViewBuilder AddFileFounder(IReactFileFounder reactFileFounder);
    }
}