namespace ViewCreator.Rendering
{
    using System;
    using System.Text;

    public abstract class RenderBase : IRender
    {
        public event EventHandler<RenderArgs> RenderBeginEvent;

        public event EventHandler<RenderArgs> RenderEndEvent;

        public IViewBuilder ViewBuilder { get; private set; }

        public StringBuilder Render(ComponentRenderingObject renderingObject, IViewBuilder viewBuilder)
        {
            this.ViewBuilder = viewBuilder;

            StringBuilder content = null;

            ComponentRenderArgs args = new ComponentRenderArgs(renderingObject);

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

        public virtual void RenderBegin(ComponentRenderArgs e)
        {
            if (RenderBeginEvent != null)
            {
                RenderBeginEvent.Invoke(this, e);
            }
        }

        public abstract StringBuilder Rendering(ComponentRenderArgs e);

        public virtual void RenderEnd(ComponentRenderArgs e)
        {
            if (RenderEndEvent != null)
            {
                RenderEndEvent.Invoke(this, e);
            }
        }
    }
}