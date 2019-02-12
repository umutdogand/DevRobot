namespace ViewCreator.Rendering
{
    using System.Text;
    using ViewCreator.Components;

    public interface IRender
    {
        StringBuilder Render(ProperyRenderingObject renderingObject, IViewBuilder viewBuilder);
    }
}