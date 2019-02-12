namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HtmlComponentRenderArgs : RenderArgs
    {
        public ProperyRenderingObject RenderingObject { get; set; }

        public HtmlComponentRenderArgs(ProperyRenderingObject renderingObject)
        {
            this.RenderingObject = renderingObject;
        }
    }
}