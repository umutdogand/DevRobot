namespace ViewCreator.React
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.Rendering;
    using System.Linq;

    public class ReactBuilder : RenderBuilder, IReactBuilder
    {

        /*
         * Uygulamaya özel react ayarlarının yapıldığı sınıf
         */

        /*
         * Minimizing eklenmeli
         */

        public override StringBuilder Render(IServiceProvider provider)
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
                            builder.Append(componentRender.Render(new ProperyRenderingObject()
                            {
                                Component = pValue,
                                PropertyInfo = prop.Key
                            }, viewBuilder));
                        }
                    }
                }
            }

            return builder;
        }
    }
}