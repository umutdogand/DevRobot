namespace ViewCreator.React
{
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;
    using ViewCreator.Rendering;
    public class InputReactRender : ReactRender
    {
        public override StringBuilder Rendering(HtmlComponentRenderArgs e)
        {
            string content = "";

            if (e.RenderingObject?.Component is IInput input && e.RenderingObject?.PropertyInfo is PropertyInfo info)
            {
                content = $"<input type={input.Type} name={input.Name}/>";

                // attributelarının atanması işlemi 
            }

            return new StringBuilder(content);
        }
    }
}
