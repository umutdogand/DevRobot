namespace ViewCreator.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using ViewCreator.Components;

    public class ProperyRenderingObject
    {
        public PropertyInfo PropertyInfo { get; set; }

        public IHtmlComponent Component { get; set; }
    }
}
