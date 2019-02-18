namespace ViewCreator.React.Rendering
{
    using System.IO;
    using System.Text;
    using ViewCreator.Helper;
    using Microsoft.Extensions.DependencyInjection;
    using ViewCreator.Rendering;

    public class ReactHtmlComponentRender : HtmlComponentRender
    {
        private readonly string _fileName = null;

        public ReactHtmlComponentRender()
        {
            this._fileName = this.GetType().Name;
        }

        public ReactHtmlComponentRender(string fileName)
        {
            this._fileName = fileName;
        }

        public StringBuilder ReadFromFile(string fileName)
        {
            using (System.IO.StreamReader Reader = new StreamReader(fileName))
            {
                return new StringBuilder(Reader.ReadToEnd());
            }
        }

        public override StringBuilder Rendering(HtmlComponentRenderArgs e)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<ViewBuilderConfig>() as ReactViewBuilderConfig;

                return ReadFromFile(Path.Combine(config.ReactFolderPath, _fileName));
            }
        }
    }
}