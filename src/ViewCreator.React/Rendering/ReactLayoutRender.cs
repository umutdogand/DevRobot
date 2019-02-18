namespace ViewCreator.React.Rendering
{
    using System.IO;
    using System.Text;
    using ViewCreator.Helper;
    using ViewCreator.Rendering;
    using Microsoft.Extensions.DependencyInjection;

    public class ReactLayoutRender : LayoutRender
    {
        private readonly string _fileName = null;

        public ReactLayoutRender()
        {
            this._fileName = this.GetType().Name;
        }

        public ReactLayoutRender(string fileName)
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

        public override StringBuilder Rendering(LayoutRenderArgs e)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<ViewBuilderConfig>() as ReactViewBuilderConfig;

                return ReadFromFile(Path.Combine(config.ReactFolderPath, _fileName));
            }
        }
    }
}