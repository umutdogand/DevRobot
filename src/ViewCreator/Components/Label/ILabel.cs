namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILabel : IHtmlComponent
    {
        string For { get; set; }
    }
}