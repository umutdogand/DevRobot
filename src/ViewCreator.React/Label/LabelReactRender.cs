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
                content = $@"
class Button extends React.Component {{
  constructor(props) {{
    super(props);
  }}
  render() {{
    return (
      <label id={{this.props.Id}} 
             name={{this.props.Name}} 
             className={{this.props.Class}} 
             style={{this.props.Style}}
             for={{this.props.For}}></label>
    );
  }}
}}";
            }

            return new StringBuilder(content);
        }
    }
}