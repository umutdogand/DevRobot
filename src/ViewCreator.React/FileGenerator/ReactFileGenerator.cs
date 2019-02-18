namespace ViewCreator.React
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Helper;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.Rendering;
    using System.Linq;

    public class ReactFileGenerator
    {
        public StringBuilder Generate(IEnumerable<Type> components, IEnumerable<Type> layouts)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var viewBuilder = provider.GetService<IViewBuilder>();

                WriteHeader(stringBuilder, viewBuilder, components, layouts);
                WriteBody(stringBuilder, viewBuilder, components, layouts);
                WriteFooter(stringBuilder, viewBuilder, components, layouts);
            }

            return stringBuilder;
        }

        private void WriteHeader(StringBuilder stringBuilder, IViewBuilder viewBuilder, IEnumerable<Type> components, IEnumerable<Type> layouts)
        {
            string header = EmbededResourceHelper.GetEmbeddedResource("FileGenerator.header.jsx",
                typeof(ReactFileGenerator).Assembly);
            stringBuilder.AppendLine(header);
        }

        private void WriteBody(StringBuilder stringBuilder, IViewBuilder viewBuilder, IEnumerable<Type> components, IEnumerable<Type> layouts)
        {
            foreach (var component in components)
            {
                var render = viewBuilder.FindRender(component);
                stringBuilder.AppendLine($@"// {component.Name}");
                stringBuilder.AppendLine(render.Render(new ComponentRenderingObject()
                {
                    ComponentType = component
                }, viewBuilder).ToString());
            }

            RenderLayout(stringBuilder, viewBuilder, layouts);
        }

        public void RenderLayout(StringBuilder stringBuilder, IViewBuilder viewBuilder, IEnumerable<Type> layouts)
        {
            string layout = EmbededResourceHelper.GetEmbeddedResource("FileGenerator.layout.jsx",
                typeof(ReactFileGenerator).Assembly);

            layouts = CheckLayouts(layouts);

            foreach (var item in layouts)
            {
                if (item.GetCustomAttributes(typeof(ILayout), true).FirstOrDefault() is ILayout first)
                {
                    var _replacedLayout = layout.Replace("___LAYOUT_NAME___", first.LayoutClassName ?? item.Name);
                    stringBuilder.AppendLine(_replacedLayout);
                }
            }
        }

        private IEnumerable<Type> CheckLayouts(IEnumerable<Type> layouts)
        {
            foreach (var item in layouts)
            {
                if (item.GetCustomAttributes(typeof(ILayout), true).FirstOrDefault() is ILayout first)
                {
                    /*
                     * TODO:
                     * Layout nesneleri check edilecek hata varsa anlaşılır şekilde hata döndürülecek.
                     * Aynı isme sahip birden fazla layout olamaz
                     */

                    yield return item;
                }
                else
                {
                    // Eğer ILayout attribute yoksa (pek mümkün değil) pass geçilecek
                }
            }
        }

        private void WriteFooter(StringBuilder stringBuilder, IViewBuilder viewBuilder, IEnumerable<Type> components, IEnumerable<Type> layouts)
        {
            string header = EmbededResourceHelper.GetEmbeddedResource("FileGenerator.footer.jsx",
                typeof(ReactFileGenerator).Assembly);
            stringBuilder.AppendLine(header);
        }
    }
}