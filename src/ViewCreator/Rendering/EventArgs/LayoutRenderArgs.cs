namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LayoutRenderArgs : RenderArgs
    {
        public IEnumerable<ComponentRenderingObject> RenderingObjects { get; set; }

        public LayoutRenderArgs(IEnumerable<ComponentRenderingObject> renderingObjects)
        {
            this.RenderingObjects = renderingObjects;
        }
    }
}