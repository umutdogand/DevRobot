namespace ViewCreator.Components
{
    using System;

    public class LayoutAttribute : Layout, ILayout
    {
        public LayoutAttribute(string name) : base(name)
        {
        }
    }
}