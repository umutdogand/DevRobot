namespace ViewCreator.React.Rendering
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        public override StringBuilder Rendering(ComponentRenderArgs e)
        {
            using (var scope = SessionScopeFactory.Current.CreateScope())
            {
                var reactViewBuilder = scope.ServiceProvider.GetService<IViewBuilder>() as IReactViewBuilder;

                var task = Next(reactViewBuilder, reactViewBuilder.ReactFileFounderList,
                    _fileName, reactViewBuilder.ReactFileFounderList.Count - 1);

                Task.WaitAll(task);

                var streamResult = task.Result;

                using (StreamReader reader = new StreamReader(streamResult))
                {
                    string text = reader.ReadToEnd();
                    return new StringBuilder(text);
                }
            }
        }

        private Task<Stream> Next(IReactViewBuilder reactViewBuilder, 
            ReadOnlyCollection<IReactFileFounder> fourderList,
            string fileName, int index)
        {
            if (index >= 0)
            {
                Task<Stream>.Run(() =>
                {
                    return fourderList.ElementAt(index)
                        .Find(reactViewBuilder, fileName,
                        () => { return Next(reactViewBuilder, fourderList, fileName, index - 1); });
                });
            }

            return null;
        }
    }
}