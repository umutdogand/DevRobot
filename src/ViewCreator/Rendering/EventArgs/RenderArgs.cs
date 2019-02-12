namespace ViewCreator.Rendering
{
    using System;

    public class RenderArgs : EventArgs
    {
        private bool _isPrevent;
        private object _state;

        public bool IsPrevent { get { return _isPrevent; } }

        public Object State { get { return _state; } set { _state = value; } }

        public void PreventRender()
        {
            _isPrevent = true;
        }
    }
}