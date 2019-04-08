namespace ViewCreator.React.Rendering
{
    using System.IO;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using MvcTool.Helper;
    using ViewCreator.Rendering;

    public class ReactRender : RenderBase
    {
        private readonly string _fileName = null;

        public ReactRender()
        {
            this._fileName = this.GetType().Name;
        }

        public ReactRender(string fileName)
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

        public override StringBuilder Rendering(ComponentRenderArgs e)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<ViewBuilderConfig>() as ReactViewBuilderConfig;
                var path = Path.Combine(config.ReactFolderPath, _fileName);

                if (File.Exists(path))
                {
                    // Eğer proje içerisinde dosya ezilmek istenirse klasor yolunda dosyayı arar
                    return ReadFromFile(Path.Combine(config.ReactFolderPath, _fileName + ".jsx"));
                }
                else
                {
                    return new StringBuilder(EmbededResourceHelper.GetEmbeddedResource("Resource.js." + _fileName + ".jsx",
                        this.GetType().Assembly));
                }
            }
        }
    }
}