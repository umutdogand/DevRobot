namespace ViewCreator.React
{
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Rendering;

    public class LabelReactRender : ReactRender
    {
        public override StringBuilder Rendering(HtmlComponentRenderArgs e)
        {
            string content = "";

            if (e.RenderingObject?.Component is ILabel label && e.RenderingObject?.PropertyInfo is PropertyInfo info)
            {
                content = $"<label for={label.For}></label>";

                // attributelarının atanması işlemi 
            }

            return new StringBuilder(content);
        }
    }
}