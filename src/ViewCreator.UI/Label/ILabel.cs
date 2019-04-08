namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ILabel : IComponent
    {
        string For { get; set; }
    }
}