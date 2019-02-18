namespace ViewCreator.Rendering
{
    using System.Text;
    using ViewCreator.Components;

    public interface IRender
    {
        IViewBuilder ViewBuilder { get; }

        StringBuilder Render(ComponentRenderingObject renderingObject, IViewBuilder viewBuilder);
    }
}