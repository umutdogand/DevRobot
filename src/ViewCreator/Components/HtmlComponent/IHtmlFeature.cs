namespace ViewCreator.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHtmlFeature
    {
        string Name { get; }

        object Value { get; }
    }
}