namespace ViewCreator.React
{
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Rendering;

    public class ButtonReactRender : ReactRender
    {
        public override StringBuilder Rendering(HtmlComponentRenderArgs e)
        {
            string content = "";

            if (e.RenderingObject?.Component is IButton button && e.RenderingObject?.PropertyInfo is PropertyInfo info)
            {
                content = $"<button name={button.Name}></button>";

                // attributelarının atanması işlemi 
            }

            return new StringBuilder(content);
        }
    }
}