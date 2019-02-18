namespace ViewCreator.React.Rendering
{
    using System;
    using System.Text;
    using ViewCreator.Components;

    public class ReactViewBuilder : ViewBuilder<IReactViewBuilder>, IReactViewBuilder
    {
        public ReactViewBuilder()
        {
            this.ViewBuilderConfig = new ReactViewBuilderConfig();
        }

        public IReactViewBuilder SetConfig(Action<ReactViewBuilderConfig> action)
        {
            action(this.ViewBuilderConfig as ReactViewBuilderConfig);

            return this;
        }

        protected override StringBuilder GeneratingReactBuilderFile(IServiceProvider provider)
        {
            ReactFileGenerator reactFileGenerator = new ReactFileGenerator();

            return reactFileGenerator.Generate(RegisteredComponents.Keys, RegisteredLayouts);
        }
    }
}