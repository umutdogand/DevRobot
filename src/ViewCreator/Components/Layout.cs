namespace ViewCreator.Components
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public abstract class Layout : FeatureBase, ILayout
    {
        public string LayoutName { get; set; }

        public string LoadUrl { get; set; }

        public string LoadHttpMethod { get; set; }

        public Layout(string layoutName)
        {
            this.LayoutName = layoutName;
        }
    }
}