namespace ViewCreator.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewCreator.Components;

    public interface IForm : IComponent
    {
        string Action { get; set; }

        string Method { get; set; }
    }
}