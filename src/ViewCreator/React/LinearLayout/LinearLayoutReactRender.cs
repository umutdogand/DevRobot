namespace ViewCreator.React
{
    using System.Linq;
    using System.Text;
    using ViewCreator.Rendering;

    public class LinearLayoutReactRender : LayoutRender
    {
        public override StringBuilder Rendering(LayoutRenderArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string content = "<div>";

            for (int i = 0; i < e.RenderingObjects.Count(); i++)
            {
                var renderingObj = e.RenderingObjects.ElementAt(i);
                var component = renderingObj?.Component;
                var info = renderingObj?.PropertyInfo;

                if (component == null || info == null)
                    continue;

                var componentRender = ViewBuilder.FindRender(component);
                content += componentRender.Render(renderingObj, ViewBuilder);

                stringBuilder.Append(content);
            }

            content += "</div>";

            return stringBuilder;
        }
    }
}