namespace ViewCreator.React.Rendering
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Threading.Tasks;

    public interface IReactFileFounder
    {
        Task<Stream> Find(IReactViewBuilder reactViewBuilder, string fileName, Func<Task<Stream>> next);
    }
}