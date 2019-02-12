namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;

    public abstract class LayoutRender : ILayoutRender
    {
        public event EventHandler<RenderArgs> RenderBeginEvent;

        public event EventHandler<RenderArgs> RenderEndEvent;

        public IViewBuilder ViewBuilder { get; private set; }

        public StringBuilder Render(IEnumerable<ProperyRenderingObject> renderingObjects, IViewBuilder viewBuilder)
        {
            this.ViewBuilder = viewBuilder;

            StringBuilder content = null;

            LayoutRenderArgs args = new LayoutRenderArgs(renderingObjects);

            for (int i = 0; !args.IsPrevent && i < 3; i++)
            {
                switch (i)
                {
                    case 0: RenderBegin(args); break;
                    case 1: content = Rendering(args); break;
                    case 2: RenderEnd(args); break;
                    default: break;
                }
            }

            return content;
        }

        public StringBuilder Render(ProperyRenderingObject renderingObject, IViewBuilder viewBuilder)
        {
            return Render(new List<ProperyRenderingObject>() { renderingObject }, viewBuilder);
        }

        public virtual void RenderBegin(LayoutRenderArgs e)
        {
            if (RenderBeginEvent != null)
            {
                RenderBeginEvent.Invoke(this, e);
            }
        }

        public abstract StringBuilder Rendering(LayoutRenderArgs e);

        public virtual void RenderEnd(LayoutRenderArgs e)
        {
            if (RenderEndEvent != null)
            {
                RenderEndEvent.Invoke(this, e);
            }
        }
    }
}