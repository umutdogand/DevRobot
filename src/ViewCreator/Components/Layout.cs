namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public abstract class Layout : FeatureBase, ILayout
    {
        public string LayoutName { get; set; }

        public Layout(string name)
        {
            this.LayoutName = name;
        }
    }
}