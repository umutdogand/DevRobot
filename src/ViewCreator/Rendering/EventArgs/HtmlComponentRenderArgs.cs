namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HtmlComponentRenderArgs : RenderArgs
    {
        public ComponentRenderingObject RenderingObject { get; set; }

        public HtmlComponentRenderArgs(ComponentRenderingObject renderingObject)
        {
            this.RenderingObject = renderingObject;
        }
    }
}