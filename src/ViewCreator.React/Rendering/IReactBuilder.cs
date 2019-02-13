namespace ViewCreator.React
{
    using ViewCreator.Components;

    public interface IReactBuilder : IViewBuilder
    {
        IReactBuilder SetReactFileUrl(string url);
    }
}