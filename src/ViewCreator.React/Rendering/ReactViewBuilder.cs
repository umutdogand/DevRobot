namespace ViewCreator.React.Rendering
{
    using System;
    using System.Text;
    using ViewCreator.Components;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.Rendering;
    using System.Linq;

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

        protected override StringBuilder Rendering(IServiceProvider provider)
        {
            var viewBuilder = provider.GetService<IViewBuilder>();

            StringBuilder builder = new StringBuilder();

            foreach (var t in RegisteredComponents)
            {
                var attributes = t.GetCustomAttributes(true);
                var props = t.GetProperties();

                if (attributes.FirstOrDefault(i => i is ILayout) is ILayout layout)
                {
                    var propDict = props.Where(i => i.GetCustomAttributes(true).Any(a => a is IHtmlComponent))
                        .ToDictionary(i => i, i => i.GetCustomAttributes(true)
                            .Where(a => a is IHtmlComponent).Select(x => x as IHtmlComponent));

                    var componentRender = viewBuilder.FindRender(layout);

                    foreach (var prop in propDict)
                    {
                        foreach (var pValue in prop.Value)
                        {
                            //builder.Append(componentRender.Render(new ComponentRenderingObject()
                            //{
                            //    Component = pValue,
                            //    PropertyInfo = prop.Key
                            //}, viewBuilder));
                        }
                    }
                }
            }

            return builder;
        }
    }
}