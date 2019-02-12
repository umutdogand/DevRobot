namespace ViewCreator.Rendering
{
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;

    public interface ILayoutRender : IRender
    {
        StringBuilder Render(IEnumerable<ProperyRenderingObject> renderingObjects, IViewBuilder viewBuilder);
    }
}