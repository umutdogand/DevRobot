namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LayoutRenderArgs : RenderArgs
    {
        public IEnumerable<ProperyRenderingObject> RenderingObjects { get; set; }

        public LayoutRenderArgs(IEnumerable<ProperyRenderingObject> renderingObjects)
        {
            this.RenderingObjects = renderingObjects;
        }
    }
}