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
                content = $@"
class Button extends React.Component {{
  constructor(props) {{
    super(props);
  }}
  render() {{
    return (
      <button name={{this.props.Name}} 
              className={{this.props.Class}} 
              style={{this.props.Style}}></button>
    );
  }}
}}";
            }

            return new StringBuilder(content);
        }
    }
}