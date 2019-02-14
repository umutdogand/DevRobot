namespace ViewCreator.React
{
    using System;
    using System.IO;
    using System.Text;
    using ViewCreator.Rendering;

    public class ReactRender : HtmlComponentRender
    {
        public string JavaScriptFolder { get;  protected set; } = "ViewCreator.React";

        public StringBuilder ReadFromFile(string fileName)
        {
            using (System.IO.StreamReader Reader = new StreamReader(Path.Combine(JavaScriptFolder, fileName)))
            {
                return new StringBuilder(Reader.ReadToEnd());
            }
        }

        public override StringBuilder Rendering(HtmlComponentRenderArgs e)
        {
            string content = "";

            if (e.RenderingObject?.Component != null && e.RenderingObject?.PropertyInfo != null)
            {
                var className = this.GetType().Name;

                return ReadFromFile(className);
            }

            return new StringBuilder(content);
        }
    }
}