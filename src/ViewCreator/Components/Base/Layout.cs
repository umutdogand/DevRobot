namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Layout : FeatureBase, ILayout
    {
        public string LayoutName { get; set ; }
    }
}