namespace ViewCreator.React.Rendering
{
    using MvcTool.Helper;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public class JsxReactFileFounder : IReactFileFounder
    {
        public async Task<Stream> Find(IReactViewBuilder reactViewBuilder, string fileName, Func<Task<Stream>> next)
        {
            var config = reactViewBuilder.ReactViewBuilderConfig;
            var folder = config.ReactFolderPath.Trim() ?? "";

            if (!folder.StartsWith("/") && !folder.StartsWith("\\"))
            {
                folder = "\\" + folder;
            }

            var path = Path.Combine(folder, fileName);

            if (File.Exists(path))
            {
                // Eğer proje içerisinde dosya ezilmek istenirse klasor yolunda dosyayı arar
                return new StreamReader(Path.Combine(folder, fileName + ".jsx")).BaseStream;
            }
            else
            {
                var resource = EmbededResourceHelper.GetEmbeddedResource("Resource.js." + fileName + ".jsx",
                    this.GetType().Assembly);

                if(resource != null)
                {
                    byte[] byteArray = Encoding.ASCII.GetBytes(resource);
                    return new MemoryStream(byteArray);
                }
            }

            return await next();
        }
    }
}