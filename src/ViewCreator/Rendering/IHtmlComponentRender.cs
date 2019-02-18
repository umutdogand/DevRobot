namespace ViewCreator.Rendering
{
    using System.Text;
    using ViewCreator.Components;

    public interface IHtmlComponentRender
    {
        IViewBuilder ViewBuilder { get; }

        StringBuilder Render(ComponentRenderingObject renderingObject, IViewBuilder viewBuilder);
    }
}