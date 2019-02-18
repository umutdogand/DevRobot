namespace ViewCreator.Rendering
{
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;

    public interface ILayoutRender : IHtmlComponentRender
    {
        StringBuilder Render(IEnumerable<ComponentRenderingObject> renderingObjects, IViewBuilder viewBuilder);
    }
}