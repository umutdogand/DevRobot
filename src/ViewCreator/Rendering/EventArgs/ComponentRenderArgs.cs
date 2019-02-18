namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ComponentRenderArgs : RenderArgs
    {
        public ComponentRenderingObject RenderingObject { get; set; }

        public ComponentRenderArgs(ComponentRenderingObject renderingObject)
        {
            this.RenderingObject = renderingObject;
        }
    }
}